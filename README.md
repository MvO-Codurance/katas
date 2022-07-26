# kata-SmartFridge
See https://katalyst.codurance.com/smart-fridge

Introduction
------------

You have been hired as a developer for FridgeCraft, a fridge manufacturer who pride themselves on their craftsmanship of delivering a quality fridge. FridgeCraft have decided to adopt the trend of making a “smart” fridge, and it’s your job to build the software to integrate into the new test model.

Requirements
------------

The Research and Development team have given you the following requirements they want your program to have for the first iteration of the test model:

*   Track items placed into and out of the fridge

*   When an item is added, the fridge must scan the item and record:

          - Item name
          - Expiration date
          - Timestamp when added


*   Every time the fridge is opened, the items **already** inside degrade their expiry by:

          - 1 hour (unopened)
          - 5 hours (opened)


*   Provide a formatted display to view the contents and their remaining expiry with the following order:

          - Any items past their expiry must be displayed first with “EXPIRED: $item.name”
          - The rest of the items are displayed by expiry with their name and the remaining days to expiry


*   An item is expired when the tracked expiry reaches midnight on the day after the expiration date.

*   Simulate days passed, so the functionality can be easily demonstrated


Helpful information
-------------------

If an item being added is already expired, you **should not** prevent that item being scanned, the user will see via the display that it has expired.

The Research and Development team have also provided the following you **do not have to worry about**:

*   Where items are placed or how full the fridge is in regards to predicting expiry.

*   How long the fridge is opened for does not affect the expiry

*   There is no limit on how many items can be added


This is just a prototype to show the stakeholders. They want you to focus on the provided requirements and cover any edge cases they didn’t think of.

Good luck, and keep your _cool_.

Example Input/Output
--------------------

You do not have to conform to the following naming conventions or data structures.

Your program should have the following API:

    Fridge {
    
        setCurrentDate()
    
        signalFridgeDoorOpened()
    
        signalFridgeDoorClosed()
    
        scanAddedItem()
    
        scanRemovedItem()
    
        simulateDayOver()
    
        showDisplay()
    
    }


You can use the following scenario as a guide and acceptance for a typical interaction run with the fridge and its display.

Setup:

    > setCurrentDate("18/10/2021")

Input:

    > signalFridgeDoorOpened()
    > scanAddedItem(name: "Milk", expiry: "21/10/21", condition: "sealed")
    > scanAddedItem(name: "Cheese", expiry: "18/11/21", condition: "sealed")
    > scanAddedItem(name: "Beef", expiry: "20/10/21", condition: "sealed")
    > scanAddedItem(name: "Lettuce", expiry: "22/10/21", condition: "sealed")
    > signalFridgeDoorClosed()
    
    > simulateDayOver()
    
    > signalFridgeDoorOpened()
    > signalFridgeDoorClosed()
    
    > signalFridgeDoorOpened()
    > signalFridgeDoorClosed()
    
    > signalFridgeDoorOpened()
    > scanRemovedItem(name: "Milk")
    > signalFridgeDoorClosed()
    
    > signalFridgeDoorOpened()
    > scanAddedItem(name: "Milk", expiry: "26/10/21", condition: "opened")
    > scanAddedItem(name: "Peppers", expiry: "23/10/21", condition: "opened")
    > signalFridgeDoorClosed()
    
    > simulateDayOver()
    
    > signalFridgeDoorOpened()
    > scanRemovedItem(name: "Beef")
    > scanRemovedItem(name: "Lettuce")
    > signalFridgeDoorClosed()
    
    > signalFridgeDoorOpened()
    > scanAddedItem(name: "Lettuce", expiry: "22/10/21", condition: "opened")
    > signalFridgeDoorClosed()
    
    > signalFridgeDoorOpened()
    > signalFridgeDoorClosed()
    
    > simulateDayOver()


Output:

    > showDisplay()
    
    EXPIRED: Milk
    Lettuce: 0 days remaining
    Peppers: 1 day remaining
    Cheese: 31 days remaining