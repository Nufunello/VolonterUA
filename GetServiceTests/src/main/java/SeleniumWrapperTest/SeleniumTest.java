package SeleniumWrapperTest;

import static com.codeborne.selenide.Selenide.$;
import com.codeborne.selenide.Condition;
import com.codeborne.selenide.Configuration;
import com.codeborne.selenide.SelenideElement;
import com.codeborne.selenide.WebDriverRunner;
import org.junit.BeforeClass;
import org.openqa.selenium.*;
import org.openqa.selenium.opera.OperaDriver;
import org.testng.Assert;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.Test;



import java.util.concurrent.TimeUnit;

import static com.codeborne.selenide.Selenide.open;

public class SeleniumTest {
    @BeforeTest
    public void testDriverOpen() {
        Configuration.browser = "opera";
        Configuration.timeout = 3000;
    }

    @Test
    public void test_Authorization() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Хочу допомогти")).click();
        $(By.id("login")).sendKeys("AndriShunkariuk");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("firstName")).sendKeys("Андрій");
        $(By.id("lastName")).sendKeys("Шинкарюк");
        $(By.id("birthdate")).sendKeys("09.12.2000");
        $(By.id("phoneNumber")).sendKeys("+380975380612");
        $(By.id("registerButton")).click();
        String expectUrl = "https://localhost:44388/VolonterEvent/Search";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Authorization_login_already_exists() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Хочу допомогти")).click();
        $(By.id("login")).sendKeys("AndriShunkariuk");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("firstName")).sendKeys("Andy");
        $(By.id("lastName")).sendKeys("Shynkariuk");
        $(By.id("birthdate")).sendKeys("09.12.2000");
        $(By.id("phoneNumber")).sendKeys("+380975380612");
        $(By.id("registerButton")).click();
        String expectUrl = "https://localhost:44388/VolonterEvent/Search";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_not_an_authorized_user_clicks_looking_for_volunteers() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Шукаю волонтерів")).click();
        $(By.id("login")).sendKeys("AndriyShunkariuk");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("firstName")).sendKeys("Андрій");
        $(By.id("lastName")).sendKeys("Шинкарюк");
        $(By.id("birthdate")).sendKeys("09.12.2000");
        $(By.id("phoneNumber")).sendKeys("+380975380612");
        $(By.id("registerButton")).click();
        $(By.id("name")).sendKeys("Ми поруч");
        $(By.id("loginButton")).click();
        $(By.id("title")).sendKeys("Допомога дітям");
        $(By.id("ValidationModel_VolonterEvent_Description_TextDescription")).sendKeys("Надає адресну, психологічну, паліативну допомогу та системно допомагає необхідними медикаментами 17 онковідділенням по всій Україні. 2500 дітей отримали допомогу фонду на суму понад 134 млн гривень.");
        $(By.id("ValidationModel_VolonterEvent_Description_Date")).sendKeys("10122020");
        $(By.id("ValidationModel_VolonterEvent_Description_Date")).sendKeys(Keys.TAB);
        $(By.id("ValidationModel_VolonterEvent_Description_Date")).sendKeys("0900PM");
        $(By.id("textAddress")).sendKeys("м.Чернівці, вул.Героїв Майдану 244");
        String expectUrl = "https://localhost:44388/volonterevent/search";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Log_in() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Увійти")).click();
        $(By.id("login")).sendKeys("AndriShunkariuk");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("loginButton")).click();
        String expectUrl = "https://localhost:44388/Home/Index";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Log_in_non_existent_password() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Увійти")).click();
        $(By.id("login")).sendKeys("AndriShunkariuk");
        $(By.id("password")).sendKeys("AndyAndy1@");
        $(By.id("loginButton")).click();
        String expectUrl = "https://localhost:44388/Home/Index";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Log_in_and_Log_out() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Увійти")).click();
        $(By.id("login")).sendKeys("AndriShunkariuk");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("loginButton")).click();
        $(By.linkText("Розлогінитись")).click();
        String expectUrl = "https://localhost:44388/personal/volonter/signin?ReturnUrl=%2Fpersonal%2Fvolonter%2Fsignout";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Log_in_and_click_Autorization() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Увійти")).click();
        $(By.id("login")).sendKeys("AndriShunkariuk");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("loginButton")).click();
        $(By.id("RegisterVoloterButton")).click();
        String expectUrl = "https://localhost:44388/personal/volonter/register";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_There_is_no_such_login() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Увійти")).click();
        $(By.id("login")).sendKeys("IvanIvanov");
        $(By.id("password")).sendKeys("IvanIvanovych11@");
        $(By.id("loginButton")).click();
        String expectUrl = "https://localhost:44388/Home/Index";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }

    @Test
    public void test_Bag_Autorization_firsname_and_lastname() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Хочу допомогти")).click();
        $(By.id("login")).sendKeys("MaryShunkariuk");
        $(By.id("password")).sendKeys("Mary12345@");
        $(By.id("firstName")).sendKeys("Мар'яна");
        $(By.id("lastName")).sendKeys("Шинкар'юк");
        $(By.id("birthdate")).sendKeys("09.12.2000");
        $(By.id("phoneNumber")).sendKeys("+380975380612");
        $(By.id("registerButton")).click();
        String expectUrl = "https://localhost:44388/Home/Index";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }

    @Test
    public void test_Autorization_firsname_and_lastname() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Хочу допомогти")).click();
        $(By.id("login")).sendKeys("AndriyTodorovich");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("firstName")).sendKeys("Андрій");
        $(By.id("lastName")).sendKeys("Shynkariuk");
        $(By.id("birthdate")).sendKeys("09.12.2000");
        $(By.id("phoneNumber")).sendKeys("+380975380612");
        $(By.id("registerButton")).click();
        String expectUrl = "https://localhost:44388/Home/Index";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Bag_Autorization_login() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Хочу допомогти")).click();
        $(By.id("login")).sendKeys("     Andriy");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("firstName")).sendKeys("Андрій");
        $(By.id("lastName")).sendKeys("Шинкарюк");
        $(By.id("birthdate")).sendKeys("09.12.2000");
        $(By.id("phoneNumber")).sendKeys("+380975380612");
        $(By.id("registerButton")).click();
        String expectUrl = "https://localhost:44388/Home/Index";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Error_birthdate() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Хочу допомогти")).click();
        $(By.id("login")).sendKeys("AndyShunkariuk");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("firstName")).sendKeys("Andy");
        $(By.id("lastName")).sendKeys("Shynkariuk");
        $(By.id("birthdate")).sendKeys("35.15.2000");
        $(By.id("phoneNumber")).sendKeys("+380975380612");
        $(By.id("registerButton")).click();
        String expectUrl = "https://localhost:44388/Home/Index";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Authorization_error_phoneNumber() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Хочу допомогти")).click();
        $(By.id("login")).sendKeys("AndyAndriyovuch");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("firstName")).sendKeys("Andy");
        $(By.id("lastName")).sendKeys("Shynkariuk");
        $(By.id("birthdate")).sendKeys("09.12.2000");
        $(By.id("phoneNumber")).sendKeys("+38097538061222");
        $(By.id("registerButton")).click();
        String expectUrl = "https://localhost:44388/Home/Index";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Authorization_phoneNumber_mts() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Хочу допомогти")).click();
        $(By.id("login")).sendKeys("AnAndriyovuch");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("firstName")).sendKeys("Andy");
        $(By.id("lastName")).sendKeys("Shynkariuk");
        $(By.id("birthdate")).sendKeys("09.12.2000");
        $(By.id("phoneNumber")).sendKeys("+380505380612");
        $(By.id("registerButton")).click();
        String expectUrl = "https://localhost:44388/VolonterEvent/Search";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Authorization_phoneNumber_life() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Хочу допомогти")).click();
        $(By.id("login")).sendKeys("AndyVasyl");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("firstName")).sendKeys("Andy");
        $(By.id("lastName")).sendKeys("Shynkariuk");
        $(By.id("birthdate")).sendKeys("09.12.2000");
        $(By.id("phoneNumber")).sendKeys("+380635380612");
        $(By.id("registerButton")).click();
        String expectUrl = "https://localhost:44388/VolonterEvent/Search";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Log_in_and_click_Volunteer_event_nearby_and_click_Logotype() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Увійти")).click();
        $(By.id("login")).sendKeys("AndriShunkariuk");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("loginButton")).click();
        $(By.linkText("Волонтерський захід поруч")).click();
        String expectUrl = "https://localhost:44388/volonterevent/search";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        $(By.id("logoHref")).click();
        String expecUrl = "https://localhost:44388/Home/Index";
        String curreUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Log_in_and_click_Volunteer_event_nearby() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Увійти")).click();
        $(By.id("login")).sendKeys("AndriShunkariuk");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("loginButton")).click();
        $(By.linkText("Волонтерський захід поруч")).click();
        String expectUrl = "https://localhost:44388/volonterevent/search";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Log_in_and_click_Personal_office_and_unsubscribe_from_the_event() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Увійти")).click();
        $(By.id("login")).sendKeys("iivanovich");
        $(By.id("password")).sendKeys("Qwerty123!");
        $(By.id("loginButton")).click();
        $(By.linkText("Особистий кабінет")).click();
        $(By.id("1")).click();
        $(By.id("3")).click();
        String expectUrl = "https://localhost:44388/volonterpersonal/index";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Log_in_and_click_I_want_to_help_and_subscribe_to_the_event() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Увійти")).click();
        $(By.id("login")).sendKeys("iivanovich");
        $(By.id("password")).sendKeys("Qwerty123!");
        $(By.id("loginButton")).click();
        $(By.linkText("Хочу допомогти")).click();
        $(By.id("1")).click();
        $(By.id("3")).click();
        String expectUrl = "https://localhost:44388/VolonterEvent/Search";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Log_in_and_click_Organize_volunteering() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Увійти")).click();
        $(By.id("login")).sendKeys("iivanovich");
        $(By.id("password")).sendKeys("Qwerty123!");
        $(By.id("loginButton")).click();
        $(By.linkText("Організувати волонтерство")).click();
        $(By.id("title")).sendKeys("Допомога онкохворим дітям");
        $(By.id("ValidationModel_VolonterEvent_Description_TextDescription")).sendKeys("Надає адресну, психологічну, паліативну допомогу та системно допомагає необхідними медикаментами 17 онковідділенням по всій Україні. 2500 дітей отримали допомогу фонду на суму понад 134 млн гривень.");
        $(By.id("ValidationModel_VolonterEvent_Description_Date")).sendKeys("9122020");
        $(By.id("ValidationModel_VolonterEvent_Description_Date")).sendKeys(Keys.TAB);
        $(By.id("ValidationModel_VolonterEvent_Description_Date")).sendKeys("0900PM");
        $(By.id("textAddress")).sendKeys("м.Чернівці, вул.Героїв Майдану 244");
        String expectUrl = "https://localhost:44388/volonterevent/organize";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Log_in_and_click_im_looking_for_volunteers() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Увійти")).click();
        $(By.id("login")).sendKeys("AndriShunkariuk");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("loginButton")).click();
        $(By.linkText("Шукаю волонтерів")).click();
        $(By.id("login")).sendKeys("AndriShunkariuk");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("firstName")).sendKeys("Андрій");
        $(By.id("lastName")).sendKeys("Шинкарюк");
        $(By.id("birthdate")).sendKeys("09.12.2000");
        $(By.id("phoneNumber")).sendKeys("+380635380612");
        $(By.id("registerButton")).click();
        String expectUrl = "https://localhost:44388/personal/volonterOrganization/register";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }


}