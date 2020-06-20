# Domain Driven Design Sample
- This basic Asp.NET Core  project created for explaining domain driven design approach.

- This project is basically bus management system.  Mainly we have 2 entities in system , you can add buses and companies. you can also do relational transactions between these 2 entity. For example you can add buses to company entity. I am going to try to basically explain domain driven design practices  with short examples on this project.


## What is Domain Driven Design?

  Domain driven design is a approach that helps us about making our code more cleanable and  easier to develop. It was created by Eric Evans. Domain Driven Design fundamentally suggest us to develop our code domain-oriented so we need to write our basic logic code in domain layer as much as we can. 

## Layers in DDD 

- **Domain Layer**
- **Application Layer**
- **Infrastructure Layer**
- **Presentation Layer**

![layersView](https://github.com/AkinSabriCam/Domain-Driven-Design-Sample/blob/master/images/layersView.PNG)

* **Domain Layer**  :   This layer is where our entities, repositories and  something else like this are located.

  - Includes entities in application.
  - Includes repository interfaces in application.
  - Includes domain services in application.

* **Domain.Shared Layer** : This layer is where our enums or constants or somethings else related to entities what we wants to share are located. When other layers want to reach any information or something like this then can do it via shared layer, this layers helps them about this transaction.

  - Includes enums related to entities.
  - Includes constants related to entities.
  - Includes helper, extension methods or localization resource files.

* **Application Layer** : This layer is where our application services are located. This layer provides to make communication with client, Every method in application service respond to client action. These services contact to presentation layer via dto classes and contact to domain layer with repositories.

  - Includes application services.
  - Includes auto mapper profile class.

* **Application.Shared Layer** : This layer is where our application service interfaces and Dto classes are located.

  - Includes Dto classes.
  - Includes application service interfaces.

* **EntityFramework (Infrastructure) Layer** : This layer is where our orm tool that it is generally entity framework and other  third party applications are located. This layer contact to every layer in application, it provides service to every layer.

  - Includes orm tools that we want to use like entity framework.

  - Includes implements of repositories and database context of application.
  - Includes extension methods.
  - Includes third party applications what we want to use.

* **Web (Presentation) Layer** : This layer is where our user interfaces and pages are located. 

  - Includes pages, components or similar things.
  - Includes auto mapper profile class for model view classes.        

  

  A sample of application service and application service interface

  ​                               ![IBusAppService](https://github.com/AkinSabriCam/Domain-Driven-Design-Sample/blob/master/images/IBusAppService.PNG)

  ![BusAppService](https://github.com/AkinSabriCam/Domain-Driven-Design-Sample/blob/master/images/BusAppService.PNG)

  

  ## Some Terms About DDD 
* **AggregateRoot Class**  :   There maybe classes and their subclasses in your project. There are classic example that is like Order and OrderLine  classes. They are related to each other  classes so you can not create OrderLine entity without Order entity. OrderLine class depends on Order class in that point we say aggregate root class to Order class and say sub class to OrderLine class.

    I tried to explain this subject with an example in this project, We have Bus and BusDetail classes in the project, Bus class is aggregate root class and BusDetail class is subclass that's why we need to implement these classes in a way will be related to each other during create or other crud transaction.

    We create the BusDetail entity in AddBusDetail method in Bus class  not with the repository.  **See the example**  

    ![BusBusDetailAggregate](https://github.com/AkinSabriCam/Domain-Driven-Design-Sample/blob/master/images/BusBusDetailAggregate.PNG)

* **Domain Service** : Domain service is different from application service. when we want to work multiple entities at same time we choose using the domain services. Application services contact using dto classes but domain services use entity classes. Domain services has own domain logic. It's methods do not response to client action directly.  

  

  ## Running the Project 

* First of all you need to create database to run the project like below example. Set default project as Web project and then set default project  EntityFramework project in pm terminal and run  **update-database** command in pm console  finally.

    ![migrationView](https://github.com/AkinSabriCam/Domain-Driven-Design-Sample/blob/master/images/migrationView.PNG)

  

* After this transaction you can run the project and basically test crud transactions and check source code.  

  ![companies](https://github.com/AkinSabriCam/Domain-Driven-Design-Sample/blob/master/images/companies.PNG)

  ![buses](https://github.com/AkinSabriCam/Domain-Driven-Design-Sample/blob/master/images/buses.PNG)

  
  I tried to explain domain driven design principles and approach with this project, I hope I was able to  help. If you have any idea or any question about this project you can create an issue or you can contact me. Thank you for your interest.

