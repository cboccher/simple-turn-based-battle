using System;

namespace SimpleRpgBattleCmd
{

	class Program
	{
		static void DisplayStats(Stats Character)
        {
			for (int count = 0; count < 5; count++)
				switch (count)
				{
					case 0:
						Console.WriteLine("\nName: " + Character.GetID());
						break;

					case 1:
						Console.WriteLine("HP: " + Character.Hp);
						break;

					case 2:
						Console.WriteLine("ATK: " + Character.Atk);
						break;

					case 3:
						Console.WriteLine("DEF: " + Character.Def);
						break;

					case 4:
						Console.WriteLine("AGI: " + Character.Agi);
						break;
				}
			Console.WriteLine("\n");
		}

		static int DamageCalculation(Stats Attacker, Stats Target, bool Defend, bool Evade)
		{
			int TargetDef = Target.Def;
			int TargetAgi = Target.Agi;

			if (Evade == true)
			{
				Random rand = new Random();
				int MrandNum = rand.Next(1, 100);

				if (MrandNum <= Target.Agi)
					return 0;
			}


			if (Defend == true)
				TargetDef *= 3;
			else
				TargetDef *= 2;

			return Attacker.Atk * 3 - TargetDef;
		}

		// Start of Main --------------------------------------------------------------------------------------------------------------------------------------------------------------

		static void Main(string[] args)
		{
			int turnCount = 1;
			Random randCPU = new Random();
			int randNum = randCPU.Next(1, 3);
			char Option;
			Stats char1 = new Stats();
			Stats char2 = new Stats();

			char1.SetID();
			Console.WriteLine("\n" + char1.GetID() + "\n" + "-------------------");
			DisplayStats(char1);

			char2.SetID();
			Console.WriteLine("\n" + char2.GetID() + "\n-------------------");
			DisplayStats(char2);

			// Battle begins from here.

			while (true)
            {

				Console.WriteLine("\n-------------------------");
				Console.WriteLine("\tTurn " + turnCount);
				Console.WriteLine("-------------------------\n\n");
				Option = 'Z';

				// --------- Player Turn ---------

				while ( !(Option == 'A' || Option == 'G' || Option == 'E') )
				{
					Console.Write("\n" + char1.GetID() + "'s Turn - Enter either \'A\' (Attack), \'G\' (Guard) or \'E\' (Evade): ");
					Option = Convert.ToChar(Console.ReadLine());
					Console.Write("\n");

					if (Option == 'A' || Option == 'G' || Option == 'E')
					{
						switch (Option)
						{
							case 'A':
								Console.WriteLine(char1.GetID() + " attacks!");
								char2.Hp -= DamageCalculation(char1, char2, char2.GetGuard(), char2.GetEvade());
								char2.SetGuard(false);
								char2.SetEvade(false);

								if (char2.Hp <= 0)
									char2.Hp = 0;

								Console.WriteLine("\n"+char2.GetID() + " current HP: " + char2.Hp + "\n");
								break;

							case 'G':
								Console.WriteLine("Player guards!");
								char1.SetGuard(true);
								break;

							case 'E':
								Console.WriteLine("Player prepares to dodge!");
								char1.SetEvade(true);
								break;
						}

						
					}
				}

				// --------- End: Player Turn ---------

				if (char2.Hp == 0)
					break;

				// --------- Computer Turn ---------

				Console.WriteLine("\n" + char2.GetID() + "'s Turn\n");
				randNum = randCPU.Next(1, 4);
				switch (randNum)
				{
					case 1:
						Console.WriteLine(char2.GetID() + " attacks!");
						char1.Hp -= DamageCalculation(char2, char1, char1.GetGuard(), char1.GetEvade());
						char1.SetGuard(false);
						char1.SetEvade(false);

						if (char1.Hp <= 0)
							char1.Hp = 0;

						Console.WriteLine("\n" + char1.GetID() + " current HP: " + char1.Hp + "\n");
						break;

					case 2:
						Console.WriteLine(char2.GetID() + " guards!");
						char2.SetGuard(true);
						break;

					case 3:
						Console.WriteLine(char2.GetID() + " prepares to dodge!");
						char2.SetEvade(true);
						break;
				}

				// --------- End: Computer Turn ---------

				if (char1.Hp == 0)
					break;

				turnCount++;
			}

			// End: Game
			Console.WriteLine("\n\n------------ Results ------------");
			if (char1.Hp <= 0)
				Console.WriteLine("\n\n" +char1.GetID() + "'s HP has dropped to 0! " + char2.GetID() + " Wins!\n");
			else
				Console.WriteLine("\n\n" +char2.GetID() + "'s HP has dropped to 0! " + char1.GetID() + " Wins!\n");
			
			DisplayStats(char1);
			DisplayStats(char2);

			Console.WriteLine("\n\nPress Enter to continue . . .");
			Console.ReadLine();
			// End of Main --------------------------------------------------------------------------------------------------------------------------------------------------------------
		}
	}
}