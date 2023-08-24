Feature: Verify Liaison Group Website

Scenario: Verify Dropdwon Integrated Care System
Given : Launch Lisison Group Website
When : Open Integrated Care System Dropdown by clicking on that
Then : Verify user should be able to see dropdown options

Scenario: Verify user should be able to click on Find More
Given : Launch Lisison Group Website
When : Click on Find More button
Then : Verify User should be able to redirect to another page

Scenario: Verify user should be able to search in home page search bar
Given : Launch Lisison Group Website
When : Enter search value "About Us" in search box
And : click on seatch icon
Then : Verify user should be able to see search results

Scenario: Verify User can navigate to career page via click on Hamburger menu
Given : Launch Lisison Group Website
When : Click on Hamburger menu
And : Click on Careers link 
Then : verify user should be able to see carrers page with URL contains "/careers"

Scenario: Verify Contact Us Section form
Given : Launch Lisison Group Website
When : Navigate to Contact Us Section
And : Enter Contact Us From Details like Full Name, Email, Organization, Subject and Message
And : Click on Submit arrow
Then : User should get success message