Feature: Sign Up
    As an unregistered user, 
    I can sign up for the site, 
    so that I’m able to make a purchase.

Scenario Outline: 1 Check successful registration
	Given User opens the '<homePage>' page
	And User clicks the Sign Up button
	When User enters '<userName>' and '<password>' on the Sign up Page
	Then User checks that the alert appears with the message '<message>'
    And User closes the Sign Up popup

	Examples:
      | homePage                             | userName    | password  | message             |
      | https://www.demoblaze.com/index.html | !&          | 123Qwe123 | Sign up successful. |
      | https://www.demoblaze.com/index.html | User Name!  | 123Qwe123 | Sign up successful. |
      | https://www.demoblaze.com/index.html | SomeName1   | q         | Sign up successful. |
      | https://www.demoblaze.com/index.html | SomeName2   | 123456789 | Sign up successful. |

Scenario Outline: 2 Check successful log in
     Given User opens the '<homePage>' page
     And User clicks the Log in button
     When User enters '<userName>' and '<password>' on the Login Page
     Then User checks that the login was successful and that the '<userName>' appears
     And User Log out 

     Examples:
      | homePage                             | userName   | password  |
      | https://www.demoblaze.com/index.html | !&         | 123Qwe123 |
      | https://www.demoblaze.com/index.html | User Name! | 123Qwe123 |     
      | https://www.demoblaze.com/index.html | SomeName1  | q         |
      | https://www.demoblaze.com/index.html | SomeName2  | 123456789 |

Scenario Outline: 3 Check the user's ability to make purchase
      Given User opens the '<homePage>' page
      When User clicks on the 'Phones' category
      And User clicks on the first product
      And User clicks Add to Cart button
      And User comebacks to the Home page
      And User clicks on the 'Laptops' category
      And User clicks on the first product
      And User clicks Add to Cart button
      And User comebacks to the Home page
      And User clicks on the 'Monitors' category
      And User clicks on the first product
      And User clicks Add to Cart button
      And User clicks on the Cart button
      Then User checks that items amount in the Cart is '<count>'
      And User clicks the Place Order button
      And User fills out the '<name>' and '<creditCard>' data
      And User clicks the Purchase button
      And User checks that the purchase info is displayed and equal to '<text>'

      Examples:
      | homePage                             | name      | creditCard | text                         | count |
      | https://www.demoblaze.com/index.html | User Name | 123456789  | Thank you for your purchase! | 3     |
