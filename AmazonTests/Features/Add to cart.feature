Feature: Add to cart
	Check correct work of adding goods to shopping cart

Background: 
	Given I open 'https://www.amazon.com/' page 
	And the title of page contains 'Amazon.com'


Scenario Outline: Add several items to cart
	Given I enter '<request>' in search textbox
	And click search button
	When I click on the first link which contains '<request>'
	And add product to cart
	Then I open shopping cart
	And I can see '<request>' product in cart

Examples: 
	| request                        |
	| Kindle Paperwhite E-reader     |
	| Microsoft Surface Book         |
	| 128GB Waterproof USB 2.0 Metal |


Scenario: Add random product from "Today's Deals" page to cart
	Given I sign in to Amazon using 'g1269068@mvrht.com' email and 'uF@DUWr1' password
	And I click "Today's Deals" link in the Navigation Menu
	And the title of page contains 'Today's Deals'
	When I click on random deal on the page
	And I remember title of the product
	And add product to cart
	Then I open shopping cart
	And I can see in cart deal that I have remembered


Scenario: Add few pieces of the same product
	Given I sign in to Amazon using 'g1269068@mvrht.com' email and 'uF@DUWr1' password
	And I enter 'Timex Men's T49961' in search textbox
	And click search button
	When I click on the first link which contains 'Timex Men's T49961'
	And I remember count of goods in cart
	And add '3' pieces to cart
	Then I can see that count of goods in cart increased on appropriate quantity


Scenario: Add product to cart
	Given I enter 'Nexus 6P Unlocked' in search textbox
	And click search button
	When I click on the first link which contains 'Nexus 6P Unlocked'
	And add product to cart
	Then I can see on the page notice with text 'Added to Cart'


Scenario: Add clothes to cart
	Given I enter 'Cali Collection T-Shirt' in search textbox
	And click search button
	When I click on the first link which contains 'Cali Collection T-Shirt'
	And I select size as 'Large'
	And add product to cart
	Then I can see on the page notice with text 'Added to Cart'
	And I open shopping cart
	And I can see 'Cali Collection' product in cart
