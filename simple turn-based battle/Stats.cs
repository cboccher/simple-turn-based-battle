using System;

class Stats
{
	string ID = "default";
	int HP;
	int ATK;
	int DEF;
	int AGI;
	bool IsGuarding;
	bool IsEvading;

	public Stats()
	{
		HP = 500;
		ATK = 50;
		DEF = 30;
		AGI = 20;
		IsGuarding = false;
		IsEvading = false;
	}

	public void SetID() { Console.Write("Enter name: "); ID = Console.ReadLine(); }
	public string GetID() { return ID; }
	public void SetGuard(bool B) { IsGuarding = B; }
	public bool GetGuard() { return IsGuarding; }
	public void SetEvade(bool B) { IsEvading = B; }
	public bool GetEvade() { return IsEvading; }
	public int Hp{ get { return HP; } set { HP = value; } }
	public int Atk { get { return ATK; } set { ATK = value; } }
	public int Def { get { return DEF; } set { DEF = value; } }
	public int Agi { get { return AGI; } set { AGI = value; } }


}
