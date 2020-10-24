# Super Service (v2.00)

## Project structure & diagrams

#### How did I structure my data?

![Model structure](https://github.com/Layland-projects/SuperService_MVC/blob/master/ReadMeContent/ModelDiagram.png?raw=true)

Firstly I extended my DB models used in this project to have additional fields I needed to display in the front end, but didn't need to store in the database, this means that If the models get updated because the scope of the application changes the view model will automatically get these fields too.

#### How did I move the data around?

![Front end structure](https://github.com/Layland-projects/SuperService_MVC/blob/master/ReadMeContent/HelperDiagram.png?raw=true)

I set up some helper classes in the front end project that required an instance of the interface my back end service implements. This allowed me to expose and inject this dependency, meaning I could test my helper methods without relying on an actual DB.

#### Also...

![API Diagram](https://github.com/Layland-projects/SuperService_MVC/blob/master/ReadMeContent/APIDiagram.png?raw=true)

I set up a small API to allow me to be able to get item information out and use it in the JaveScript on some of the pages. As you can see there is no relation between the bottom items (the DB Models) and the top items (the API Models), this was intentional.

I did this for 2 reasons:

1. It meant that If these DB models started to store more data, perhaps sensitive data they weren't by default being sent back through the API for all to see.
2. Many to many relations in objects don't map out well to Json and cause problems when trying to Serialize or Deserialize it so this gave a flatter representation of what an Item actually is.

## Summary

I got a few things to take away from doing this:

1. Working without any amount of project board or user stories on a task like this is difficult (I intended to not use them to see the level of impact it would have). Although writing out all the user stories with strict definitions takes time, it would have saved me time in the long run and helped keep me focused on one task at a time.
2. MVC by nature is a pattern intended to have a proper separation of concerns and keep your couplings loose, almost giving you a modular feel with your application. So if necessary you can swap out an entire layer in place of another (change DB providers or formats for instance).
3. Compared to WPF it feels like you're working with far less constraints, having JavaScript as an additional tool that you can use for almost anything was so useful while doing this. It meant that I could manipulate the DOM based off the users actions for an overall better feel.
4. Styling, although more complicated with CSS than WPF's XAML styling there is far more documentation out there to get you started, good libraries such as bootstrap to help you along too.

Overall I really enjoyed doing this, although I didn't get to implement all of the features I had in my original project I added some new things and I think gave it a better overall aesthetic.