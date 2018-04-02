Feature: Denver Craigslist Navigation Check
	In order to get to desired place
	As a user
	I want to have proper navigation through denver craigslist site

Background: 
	Given I open https://denver.craigslist.org/ page
	 And I can see "denver" text at the top
	 And there is "Craigslist" link which navigates to "www.craigslist.org/about/sites" page 


Scenario Outline: Navigation through menu 
	Given I click on "<Menu Item>" link under "for sale" section
	 And I see <Number> of submenu links
	 And first submenu link has name "<Name of Item>"
	When I click on "<Name of Item>" submenu link
	 And Remember name of the first lot
	 And Click on it
	Then I expect that name of opened lot is equal to that one that I have remembered
	 And I go back using browser's back button
	 And I expect to be navigated to the page which title contains 'denver <Menu Item> - craigslist'

Examples: 
	| Menu Item    | Number | Name of Item       |
	| bikes 		| 6      | ALL BICYCLES |
	| cars & trucks | 3      | ALL CARS & TRUCKS  |


Scenario: Search
	Given I click on "bikes" link under "for sale" section
	 And I click on "ALL PARTS & ACCESSORIES" submenu link
	When I enter 'nice bike' in search box
	 And press Search button
	Then I expect to see page with the title containing "nice bike"
	 And I expect at least 1 result to be displayed on the page

	
Scenario Outline: Check footer links
	Given Footer link on the <Index> place has name "<Link Name>"
	And I remember link address of "<Link Name>"
	When I click on "about" link
	Then I expect that page title contains "craigslist | about"
	And I expect that the item "<Detailed Name>" references to url that I have remembered
	
	Examples: 
	| Index | Link Name | Detailed Name          |
	| 0     | help      | CL Help Pages          |
	| 1     | safety    | Avoiding Scams & Fraud |
	| 4     | cl jobs   | CL Jobs                |
