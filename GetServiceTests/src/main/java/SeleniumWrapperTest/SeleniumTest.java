package SeleniumWrapperTest;

import static com.codeborne.selenide.Selenide.$;

import com.codeborne.selenide.Condition;
import com.codeborne.selenide.Configuration;

import com.codeborne.selenide.SelenideElement;
import com.codeborne.selenide.WebDriverRunner;

import org.junit.BeforeClass;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.opera.OperaDriver;
import org.testng.Assert;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.Test;


import static com.codeborne.selenide.Selenide.open;

public class SeleniumTest {
    @BeforeTest
    public void testDriverOpen() {
        Configuration.browser = "opera";
        Configuration.timeout = 2000;
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
    public void test_Log_in_and_click_About_us() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Увійти")).click();
        $(By.id("login")).sendKeys("AndriShunkariuk");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("loginButton")).click();
        $(By.linkText("Про нас")).click();
        String expectUrl = "https://localhost:44388/info/aboutUs";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }
    @Test
    public void test_Log_in_and_click_Organize_volunteering() throws InterruptedException {
        String expectedUrl = "https://localhost:44388";
        open(expectedUrl);
        $(By.linkText("Увійти")).click();
        $(By.id("login")).sendKeys("AndriShunkariuk");
        $(By.id("password")).sendKeys("AndyAndy1111@");
        $(By.id("loginButton")).click();
        $(By.linkText("Організувати волонтерство")).click();
        $(By.id("title")).sendKeys("Допомога українським військовим");
        $(By.id("ValidationModel_VolonterEvent_Description_TextDescription")).sendKeys("Фонд \"Повернись живим\" – один із найбільших фондів допомоги українським військовим у зоні АТО. Спеціалізується на технічному забезпеченні, насамперед, на нічній оптиці. Крім того, займається навчальними, медичними, психологічними та іншими проектами.");
        $(By.id("ValidationModel_VolonterEvent_Description_Date")).sendKeys("20.12.2020   09:00");
        $(By.id("textAddress")).sendKeys("м.Чернівці, вул.Героїв Майдану 244");
        $(By.id("registerButton")).click();
        String expectUrl = "https://localhost:44388/volonterevent/organize";
        String currenUrl = WebDriverRunner.url();
        Assert.assertEquals(currenUrl,expectUrl);
        Thread.sleep(15000);
    }


}