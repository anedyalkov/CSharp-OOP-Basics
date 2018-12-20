﻿using DungeonsAndCodeWizards.Core;
using DungeonsAndCodeWizards.Factories;
using System;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main(string[] args)
		{
            DungeonMaster dungeonMaster = new DungeonMaster();
            var engine = new Engine(dungeonMaster);
            engine.Run();
		}
	}
}