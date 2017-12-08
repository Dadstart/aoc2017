using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day7
{
	class Program
	{
		private List<string> children;
		public string Name { get; set; }
		public int Weight { get; set; }
		public IReadOnlyList<string> Children
		{
			get
			{
				return children?.AsReadOnly();
			}
		}

		public void AddChild(string child)
		{
			if (children == null)
			{
				children = new List<string>();
			}
			children.Add(child);
		}

	}

	class ProgramTower
	{
		HashSet<string> missingChildren = new HashSet<string>();
		HashSet<string> unparentedPrograms = new HashSet<string>();
		Dictionary<string, Program> allPrograms = new Dictionary<string, Program>();

		public void Add(Program program)
		{
			// add to list of programs
			allPrograms.Add(program.Name, program);

			if (missingChildren.Contains(program.Name))
			{
				// found the missing child, remove from list
				missingChildren.Remove(program.Name);
			}
			else
			{
				// haven't seen it's parent, save it as unparented
				unparentedPrograms.Add(program.Name);
			}

			if (program.Children != null)
			{
				foreach (var child in program.Children)
				{
					if (!allPrograms.ContainsKey(child))
					{
						// haven't seen child yet
						missingChildren.Add(child);
					}
					else if (unparentedPrograms.Contains(child))
					{
						// found the parent, remove
						unparentedPrograms.Remove(child);
					}
				}
			}
		}

		public Program Root
		{
			get
			{
				if (unparentedPrograms.Count != 1)
				{
					throw new Exception("Either no root or too many");
				}

				string root = unparentedPrograms.Take(1).First();
				return allPrograms[root];
			}
		}
	}
}
