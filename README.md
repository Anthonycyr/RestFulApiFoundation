# RestFul Api
using C # and .NET Core 



The Rest Api will allow us to know and to manipulate the status of all the relevant entities of the operational database.

To make it work, use the corect endpoint for your needs:

- Retrieving the current status of a specific Battery: **// GET: api/Batteries/1**
- Changing the status of a specific Battery: **// POST: api/Batteries**
- Retrieving the current status of a specific Column: **// GET: api/Columns/5**
- Changing the status of a specific Column: **// POST: api/Columns**
- Retrieving the current status of a specific Elevator: **// GET: api/Elevators/10**
- Changing the status of a specific Elevator: **// POST: api/Elevators**
- Retrieving a list of Elevators that are not in operation at the time of the request: **// GET: api/Elevators/status**
- Retrieving a list of Buildings that contain at least one battery, column or elevator requiring intervention: **//  GET: api/Buildings/BuildingIntervention**
- Retrieving a list of Leads created in the last 30 days who have not yet become customers: **// GET: api/Leads/CustomerLeads**

This API is debloy on a Azure Server and establish a connection with the MySQL transactional database that serves the Ruby on Rails application.

You can also try out the 3 new API Calls that i've created for the consolidation week:

- a Get for PendingInterventions, which returns all interventions that are currently of status pending 
- a patch for InProgress, which changes the status of a pending intervention to in progress and adds a start time to the intervention 
- and a patch for Completed, which changes the status of an in progress intervention to Completed and adds an end time to the intervention

Week 11 \
we used to create the intervbention form -/getId/{company_email} to get the custer id with his email\
                                         -/getCustomerBuildings/{customer_id} to get the buildings of the customer\
                                         -/getCustomerBattery/{building_id} to get the batteries of the customer buildings selected\
                                         -/getCustomerColumn/{battery_id} to get the Column of the selected battery\
                                         -/getCustomerElevator/{column_id} to get the elevator of the selected column\
 to post the intervention form(it is currently not working because of the CORS bug) -/api/Interventions\
 to put the new contact info (same problem as the post intervention) -/api/Customers/ContactUpdate/{id}&{company_name}&{company_headquarter}&{company_contact}&{company_description}&{service_technical_authority_name}&{technical_authority_phone}&{service_technical_authority_email}

you can try each method with the try it out button, and then the excute button, although the patch requires you to select the appropriate intervention by inputting an ID before clicking the execute button.

You could also use postman, for the GET method => https://apexrocketsrestful.herokuapp.com/api/Interventions/PendingInterventions for the PATCH (inprogress) : https://apexrocketsrestful.herokuapp.com/api/Interventions/inprogress/{id} //change {id} for intervention you want for the PATCH (completed) : https://apexrocketsrestful.herokuapp.com/api/Interventions/completed/{id} //change {id} for intervention you want

###### ***Team New Moon***
