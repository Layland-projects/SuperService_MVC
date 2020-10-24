# Super Service (v2.00)

### Project structure & diagrams

#### <u>DB models and View models</u>

![Model structure](https://github.com/Layland-projects/SuperService_MVC/blob/master/ReadMeContent/ModelDiagram.png?raw=true)

Firstly I extended my DB models used in this project to have additional fields I needed to display in the front end, but didn't need to store in the database, this means that If the models get updated because the scope of the application changes the view model will automatically get these fields too.

#### How did I move the data around?

![Front end structure](https://github.com/Layland-projects/SuperService_MVC/blob/master/ReadMeContent/HelperDiagram.png?raw=true)

I set up some helper classes in the front end project that required an instance of the interface my back end service implements. This allowed me to expose and inject this dependency, meaning I could test my helper methods without relying on an actual DB.