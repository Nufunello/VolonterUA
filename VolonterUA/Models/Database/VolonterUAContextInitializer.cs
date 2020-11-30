using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace VolonterUA.Models.Database
{
    public class VolonterUAContextInitializer : DropCreateDatabaseAlways<VolonterUAContext>
    {
        private List<Volonter> AddVolonters(VolonterUAContext context)
        {
            return new List<Volonter>
            {
                context.AddVolonter(new UserLoginDataModel
                {
                    Login = "iivanovich",
                    Password = "Qwerty123!",
                    UserInfo = new UserInfo
                    {
                        FirstName = "Іван",
                        LastName = "Іванович",
                        Birthdate = DateTime.Parse("18/08/1999"),
                        PhoneNumber = "+380995123380"
                    }
                }),
                context.AddVolonter(new UserLoginDataModel
                {
                    Login = "pro_volonter",
                    Password = "Karma33!",
                    UserInfo = new UserInfo
                    {
                        FirstName = "Степан",
                        LastName = "Пашак",
                        Birthdate = DateTime.Parse("8/01/2001"),
                        PhoneNumber = "+380995123381"
                    }
                }),
                context.AddVolonter(new UserLoginDataModel
                {
                    Login = "che_volonter",
                    Password = "CheBest1!",
                    UserInfo = new UserInfo
                    {
                        FirstName = "Владислав",
                        LastName = "Гаврилов",
                        Birthdate = DateTime.Parse("11/09/1986"),
                        PhoneNumber = "+380995123382"
                    }
                }),
                context.AddVolonter(new UserLoginDataModel
                {
                    Login = "burger12",
                    Password = "Ozzy1aa!",
                    UserInfo = new UserInfo
                    {
                        FirstName = "Ігорь",
                        LastName = "Лузян",
                        Birthdate = DateTime.Parse("28/10/1990"),
                        PhoneNumber = "+380995123383"
                    }
                }),
                context.AddVolonter(new UserLoginDataModel
                {
                    Login = "admin123",
                    Password = "Admin123!",
                    UserInfo = new UserInfo
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        Birthdate = DateTime.Parse("01/01/1900"),
                        PhoneNumber = "+380995123386"
                    }
                })
            };
        }

        private List<VolonterOrganization> AddOrganizations(VolonterUAContext context)
        {
            var organizator1 = context.AddVolonter(new UserLoginDataModel
            {
                Login = "organizator1",
                Password = "Qwerty123!",
                UserInfo = new UserInfo
                {
                    FirstName = "Борис",
                    LastName = "Добрович",
                    Birthdate = DateTime.Parse("03/04/1970"),
                    PhoneNumber = "+380995123388"
                }
            });

            var organizator2 = context.AddVolonter(new UserLoginDataModel
            {
                Login = "karma_ambassador",
                Password = "Karma33!",
                UserInfo = new UserInfo
                {
                    FirstName = "Nazar",
                    LastName = "Stepulin",
                    Birthdate = DateTime.Parse("18/03/1977"),
                    PhoneNumber = "+380995123389"
                }
            });

            var list = new List<VolonterOrganization>
            {
                new VolonterOrganization
                {
                    Name = "Про Волонтерський Рух",
                    Representative = organizator1.UserInfo
                },
                new VolonterOrganization
                {
                    Name = "Волонтери України",
                    Representative = organizator2.UserInfo
                }
            };
            context.VolonterOrganizations.AddRange(list);
            context.SaveChanges();

            return list;
        }

        private UpcomingVolonterEvent AddUpcomingEvent(VolonterUAContext context, VolonterOrganization organizator, Description description)
        {
            var volonterEvent = new VolonterEvent
            {
                Description = description,
                VolonterOrganization = organizator
            };
            return context.PostEvent(volonterEvent);
        }

        private InProgressVolonterEvent AddInProgressEvent(VolonterUAContext context, VolonterOrganization organizator, Description description)
        {
            var upComingVolonterEvent = AddUpcomingEvent(context, organizator, description);
            return context.StartEvent(upComingVolonterEvent);
        }

        private FinishedVolonterEvent AddFinishedEvent(VolonterUAContext context, VolonterOrganization organizator, Description description, IEnumerable<Volonter> volonters)
        {
            var inProgressVolonterEvent = AddInProgressEvent(context, organizator, description);
            foreach (var volonter in volonters)
            {
                inProgressVolonterEvent.Volonters.Add(volonter);
            }

            return context.FinishEvent(inProgressVolonterEvent);
        }

        protected override void Seed(VolonterUAContext context)
        {
            var volonters = AddVolonters(context);
            var organizators = AddOrganizations(context);

            var upcomingEvent1 = AddUpcomingEvent(context, organizators[1], new Description
            {
                Title = "День Миколая для сиріт",
                Date = DateTime.Parse("6/12/2020"),
                TextDescription = "В холодну пору року, багатьом діткам не вистачає тепла, особливо сиротам. " +
                "Тому на день Миколая ми плануємо принести подаруночків та смаколиків діткам, що залишись без батьків, " +
                "бо крім нас в них нікого немає",
                Location = new Location { TextAddress = "Головна вулиця, 169, Чернівці" }
            });
            upcomingEvent1.Volonters = new List<Volonter> { volonters[1], volonters[0] };
            context.SaveChanges();

            var upcomingEvent2 = AddUpcomingEvent(context, organizators[0], new Description
            {
                Title = "День обнімань",
                Date = DateTime.Parse("4/12/2020 17:30"),
                TextDescription = "Вчені довели, що доброзичливі дотики підвищують імунітет, стимулюють центральну нервову систему, " +
                "підвищують у крові рівень гемоглобіну, а також іншого гормону — окситоцину, що викликає доброзичливе " +
                "ставлення до інших людей",
                Location = new Location { TextAddress = "Соборна площа 1, Чернівці" }
            });
            upcomingEvent2.Volonters = new List<Volonter> { volonters[1], volonters[0] };
            context.SaveChanges();

            var upcomingEvent3 = AddUpcomingEvent(context, organizators[0], new Description
            {
                Title = "День обнімань2",
                Date = DateTime.Parse("4/12/2020 17:30"),
                TextDescription = "Вчені довели, що доброзичливі дотики підвищують імунітет, стимулюють центральну нервову систему, " +
                "підвищують у крові рівень гемоглобіну, а також іншого гормону — окситоцину, що викликає доброзичливе " +
                "ставлення до інших людей",
                Location = new Location { TextAddress = "Соборна площа 1, Чернівці" }
            });
            upcomingEvent3.Volonters = new List<Volonter> { volonters[1], volonters[0] };
            context.SaveChanges();

            var upcomingEvent4 = AddUpcomingEvent(context, organizators[0], new Description
            {
                Title = "День обнімань3",
                Date = DateTime.Parse("4/12/2020 17:30"),
                TextDescription = "Вчені довели, що доброзичливі дотики підвищують імунітет, стимулюють центральну нервову систему, " +
                "підвищують у крові рівень гемоглобіну, а також іншого гормону — окситоцину, що викликає доброзичливе " +
                "ставлення до інших людей",
                Location = new Location { TextAddress = "Соборна площа 1, Чернівці" }
            });
            upcomingEvent4.Volonters = new List<Volonter> { volonters[1], volonters[0] };
            context.SaveChanges();

            var upcomingEvent5 = AddUpcomingEvent(context, organizators[0], new Description
            {
                Title = "День обнімань4",
                Date = DateTime.Parse("4/12/2020 17:30"),
                TextDescription = "Вчені довели, що доброзичливі дотики підвищують імунітет, стимулюють центральну нервову систему, " +
                "підвищують у крові рівень гемоглобіну, а також іншого гормону — окситоцину, що викликає доброзичливе " +
                "ставлення до інших людей",
                Location = new Location { TextAddress = "Соборна площа 1, Чернівці" }
            });
            upcomingEvent5.Volonters = new List<Volonter> { volonters[1], volonters[0] };
            context.SaveChanges();

            var upcomingEvent6 = AddUpcomingEvent(context, organizators[0], new Description
            {
                Title = "День обнімань5",
                Date = DateTime.Parse("4/12/2020 17:30"),
                TextDescription = "Вчені довели, що доброзичливі дотики підвищують імунітет, стимулюють центральну нервову систему, " +
                "підвищують у крові рівень гемоглобіну, а також іншого гормону — окситоцину, що викликає доброзичливе " +
                "ставлення до інших людей",
                Location = new Location { TextAddress = "Соборна площа 1, Чернівці" }
            });
            upcomingEvent6.Volonters = new List<Volonter> { volonters[1], volonters[0] };
            context.SaveChanges();

            var inProgressEvent1 = AddInProgressEvent(context, organizators[1], new Description
            {
                Title = "Права усім",
                Date = DateTime.Now,
                TextDescription = "Чи замислювались ви наскільки добре знають свої права ваші співвітчизнки? " +
                "Чи хотіли би ви допомогти людям краще розуміти свої права та обов'язки? Якщо так і ви маєте освіту в юриспруденції " +
                "або навчаєтесь але маєте що розповісти, то ми запрошуємо вас бути докладачами на онлайн-конференції",
                Location = new Location { TextAddress = "zoom.com/id123" }
            });
            inProgressEvent1.Volonters = new List<Volonter> { volonters[2], volonters[3] };
            context.SaveChanges();

            var finishedEvent = AddFinishedEvent(context, organizators[0], new Description
            {
                Title = "Навчаємо діток правилам безпеки",
                Date = DateTime.Parse("15/11/2020, 07:22:16"),
                TextDescription = "15 листопада - день жертв ДТП, в такій день розумієшь, що навіть найменше порушення правил дорожнього руху " +
                "можуть привести до фатальних наслідків. Тому ми проводимо маленький курс для діточок, про правила поведінки на дорозі та не тільки" +
                ", якщо бажаєшь допомогти наступному поколіню та знаєш як себе треба поводити на дорозі та в надзвичайних ситуаціях - реєструйся",
                Location = new Location { TextAddress = "zoom.com/id456" }
            }, new List<Volonter> { volonters[0], volonters[3] });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}