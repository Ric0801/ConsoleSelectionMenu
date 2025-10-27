# General information
- This is a small project which I made to save time in school since this is something I use quite often. I am not planning on doing regular updates or additions, this was just a small project out of lazyness to not rewrite the same code over and over in different projects.

# 1 Selection Menu
# 1.1 Using the Console Selection Menu
- The Selection Menu can be initiated the follow way:
```cs
  - User selectedUser = new SelectionMenu<User>(users, u => u.Name).Show()
  - string selected = new SelectionMenu<string>(listOfStrings, s => s).Show()
```
# 1.2 Navigating the Console Selection Menu
- The selection menu can be navigated using the following keys:
  - Arrow Up
  - Arrow Down
  - W
  - S
  - Enter: Select the current item
# 2 Checkbox Selection
# 2.1 Using the CheckboxSelection:
- With the Checkbox selection, multiple items can be selected and will be returned as List<T>
- The Initiation follows the same rules as the Selection Menu
```cs
  - List<User> userSelections = new SelectionMenu<User>(users, u => u.Name).Show()
  - List<string> selectedStrings = new SelectionMenu<string>(listOfStrings, s => s).Show()
```
# 2.2 Navigating the Checkbox Selection:
- The Checkbox selection can be navigated using the following keys:
  - Arrow Up
  - Arrow Down
  - W
  - S
  - Spacebar: to select/unselect the current item
  - Enter: Returns all selected items