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
                    UserInfo = new UserInfoModel
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
                    UserInfo = new UserInfoModel
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
                    UserInfo = new UserInfoModel
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
                    UserInfo = new UserInfoModel
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
                    UserInfo = new UserInfoModel
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
                UserInfo = new UserInfoModel
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
                UserInfo = new UserInfoModel
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
                    Representative = organizator1.User
                },
                new VolonterOrganization
                {
                    Representative = organizator2.User
                }
            };
            context.VolonterOrganizations.AddRange(list);

            return list;
        }

        private UpcomingVolonterEvent AddUpcomingEvent(VolonterUAContext context, VolonterOrganization organizator, Description description)
        {
            var volonterEvent = new VolonterEvent
            {
                Description = description,
                Organizations = new List<VolonterOrganization> { organizator }
            };
            context.VolonterEvents.Add(volonterEvent);

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
                inProgressVolonterEvent.VolontersAtEvent.Add(volonter);
            }

            return context.FinishEvent(inProgressVolonterEvent);
        }

        protected override void Seed(VolonterUAContext context)
        {
            var volonters = AddVolonters(context);
            var organizators = AddOrganizations(context);

            var upcomingEvent = AddUpcomingEvent(context, organizators[0], new Description
            {
                Title = "День Миколая для сиріт",
                Date = DateTime.Parse("6/12/2020"),
                TextDescription = "В холодну пору року, багатьом діткам не вистачає тепла, особливо сиротам. " +
                "Тому на день Миколая ми плануємо принести подаруночків та смаколиків діткам, що залишись без батьків, " +
                "бо крім нас в них нікого немає",
                Address = new Address { TextAddress = "Головна вулиця, 169, Чернівці" }
            });
            upcomingEvent.Subscribers.Add(volonters[0]);
            upcomingEvent.Subscribers.Add(volonters[1]);

            var inProgressEvent = AddInProgressEvent(context, organizators[0], new Description
            {
                Title = "Права усім",
                Date = DateTime.Parse("10/12/2020"),
                TextDescription = "Чи замислювались ви наскільки добре знають свої права ваші співвітчизнки? " +
                "Чи хотіли би ви допомогти людям краще розуміти свої права та обов'язки? Якщо так і ви маєте освіту в юриспруденції " +
                "або навчаєтесь але маєте що розповісти, то ми запрошуємо вас бути докладачами на онлайн-конференції",
                Address = new Address { TextAddress = "zoom.com/id123" }
            });
            inProgressEvent.VolontersAtEvent.Add(volonters[1]);
            inProgressEvent.VolontersAtEvent.Add(volonters[2]);

            var finishedEvent = AddFinishedEvent(context, organizators[1], new Description
            {
                Title = "Навчаємо діток правилам безпеки",
                Date = DateTime.Parse("15/11/2020"),
                TextDescription = "15 листопада - день жертв ДТП, в такій день розумієшь, що навіть найменше порушення правил дорожнього руху " +
                "можуть привести до фатальних наслідків. Тому ми проводимо маленький курс для діточок, про правила поведінки на дорозі та не тільки" +
                ", якщо бажаєшь допомогти наступному поколіню та знаєш як себе треба поводити на дорозі та в надзвичайних ситуаціях - реєструйся",
                Address = new Address { TextAddress = "zoom.com/id456" }
            }, new List<Volonter> { volonters[1], volonters[3] });

            base.Seed(context);
        }
    }
}