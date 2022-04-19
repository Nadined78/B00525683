## COM741 Web Applications Development

### Practical 11 (Javascript)

You will find a set of HTML files in a folder named `practical` int the `wwwroot` folder of the SMS solution. These are not processed by the razor view engine and are just served as plain HTML files which we can use to learn how JS can be used to manipulate the DOM. You should run the application as normal, then you can access each question via the browser by using a url e.g. `http://localhost:5000/practical/q1.html`

1. Complete ```q1.html``` by adding code to the script tag to

    * Create a const variable ```greet``` and initialise with a reference to the div element with id ```greet```
    * Set the ```innerText``` of the element to ```Hello, Ciao, Hallo Bonjour```
    * Update the element styles (accessed via ```greet.style.XXXX```) by configuring the color to "blue" and fontSize to "24px".

2. Complete ```q2.html``` by adding code to the script tag to

    * Obtain a reference to the div element with id ```greet```
    * Update the classList by adding bootstrap classes ```text-success``` and ```fs-3``` (must be added individually)
    * Set the innerHTML of the element to following html template literal (enclosed in backticks). Note how we can change into JS mode by using ${} to enclose any Javascript content. In this case we are simply outputting the current date/time
    
    ```    
    `<p>Hello, Ciao, Hallo, Bonjour </p>
     <p>Time is now  ${new Date().toLocaleTimeString()}</p>`
    ```
 
3.  Complete ```q3.html``` by 

    * Add a button element at end of container div with button text ```Toggle```. Style as a bootstrap primary button. Add the onclick property to call the ```toggleStyle()``` function
    * Complete the toggle style function to toggle the ```greet``` div element classes ```text-success``` and ```fs-3``` . Note you can use the ```classList.toggle(..)``` function. 


4. Complete ```q4.html``` by completing the ```toggleTimeStamp()``` function so that it
    
    * Obtains a reference to the element with id ```app```
    * Obtain a reference to the element with id ```ts```
    * Check if ```ts``` is null and if so 
        - then create a new ```p``` element, 
        - set its ```id``` to ```ts```
        - add ```fs-1``` to the element classList
        - set its innerText to following interpolated string (inside backticks) ```Timestamp ${new Date().toLocaleTimeString()}```
         
    * otherwise if ```ts``` is not null then remove the element from the DOM by calling ```ts.remove()```

5. Complete ```q5.html``` so that it simulates an interactive task list where tasks can be added dynamically to the list

    * Add two buttons labeled "Add" and "Clear". Add onclick handlers to the buttons to call the addTask() and clearTasks() functions respectively
    * Complete the ```addTask()``` function so that it
        - obtains references to the ```tasks``` list and the ```task``` input elements
        - Create a new ```li``` element
        - give the ```li``` element a classlist value of ```list-group-item```
        - set the ```li``` element innerText to the input field value
        - clear the input field value
        - append the ```li``` element to the ```tasks``` list
        - reset the input field value to an empty string 
    * Complete the ```clearTasks``` function so that it
        - obtains a reference to the ```tasks`` list
        - uses a loop to remove each element from the list 
    * OPTIONAL: add an event handler to the input so that pressing enter key will also trigger a call to addTask()

6. Using what you learned in Q5 create a simple ticket search page to retrieve and display a list of matching tickets. 
    * Add a button and configure its `onclick` handler to call a `search()` function 
    * Add an input field and give it a suitable id so that we can programatically access the content of the field when we click the button 
    * Add a `search()` function to the script that uses fetch to call the search ticket api using the value of the input field as the query parameter. The api url would look like `` `/api/ticket/search?query=${q}` `` , where q would be the value entered in the input field. 
    * Display the tickets returned using suitable html elements (e.g. the data list from q5, a simple set of divs or even a table!!)   

