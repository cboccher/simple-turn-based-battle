- Opened up this repository to see if i can make a simple turn-based battle system limited by certain conditions which are mentioned below.
- Turned out to be a spaghetti code since i made this in such a short time, may or may not push updates later on.

  		1) Player turn begins.

		2) Player has to choose between 3 options: Attack, Guard, Evade.
				
			+ Player has to enter either 'A', 'G' or 'E' to pick an action.

			+ User input is continuously asked for, if the user didn't enter a valid option.

		3) If the player picked the option "Attack", DamageCalculation() method is called.

  			+ Target's current HP will be displayed on screen right after.

  			+ A condition check is committed to see if target HP equals 0 or not.

			+ If the Player chose "Attack" and the target picked "Guard/Evade" beforehand (except for Turn 1 since the Player always goes first), IsGuarding/IsEvading is set to false after DamageCalculation().

		4) If the Player picked the option "Guard/Evade", IsGuarding/IsEvading are switched to true and Player Turn ends.
  
		5) Computer turn begins.

		6) Computer decides between these 3 options randomly.

			+ If the computer chose to Attack, a condition check is done if Player HP equals 0 or not. Also, if the Player picked "Guard/Evade" before, IsGuarding/IsEvading is set to false after DamageCalculation().

		7) Computer ends turn.

		8) If an actor HP drops to 0, game ends and a text is displayed on screen to announce which actor was defeated and who has won.


Known Issues
--------------

- The Player/Computer can be in Guard and Evade state at the same time. This happens if either one of these options is picked first and the other
  is picked on the next turn.



Additions/Changes that can be added/made
--------------------------------------------------

+ IsGuarding and IsEvading switching back to false after exactly 1 turn.
+ Giving user the option to edit their stats.
+ Adding a difficulty option to decide on Computer's stats and setting a range for each stat.
+ Skills, Weapons, Armor and Items.
+ Reducing the amount of if-else conditions.
+ Increasing the amount of players who can participate.
