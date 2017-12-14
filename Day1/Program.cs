using System;
using Utils;

namespace Day1
{
	class Program
	{
		const string Part1Input = "878938232157342756754254716586975125394865297349321236586574662994429894259828536842781199252169182743449435231194436368218599463391544461745472922916562414854275449983442828344463893618282425242643322822916857935242141636187859919626885791572268272442711988367762865741341467274718149255173686839265874184176985561996454253165784192929453678326937728571781212155346592432874244741816166328693958529938367575669663228335566435273484331452883175981955679335327231995452231118936393192583338222595982522833468533262224874637449624644318418748617949417939228988293391941457722641936417456243894182668197174255786445994567477582715692336249243254711653529871336129825735249667425238573952339922948214218872417858525199642194588448543565474847272984232637466664695217176358283788781843171636841215675851778984619377575696447366844854289534215286959727688419731976631323833892247438149829975856161755122857643731945913335556288817112993911694972667656914238999291831997163412548977649491227219477796124134958527843213824792685117696631512141241496451845758655276186597724748432996276498527911292531185292149948139724345841584782352214921634858734671118495424143437282979243347831258285851259579133433182387444656386679831584933397915132785411686688447731696776459621924821667112751789884987883991845818513249994767543526169463766975791464756526911587399764736557959464923353896921342944821833991457125256329564489631352268722457628514564128231487382111682976886838192412996932924373337524262135399256658638418515239876732866596731888779532573243713128238419234963195589987539467221517535272384899524386267268959484881379944796392255419838743164714275463459351741296586465213689853743856518583451849661592844879264196761867481258778393623584884535246239794178981387632311238115362178576899121425428114696158652976277392224226268242332589546757477683398264294929442592131949398261884548427951472128841328376819241955153423452531538413492577262348369581399925647624623868299468436859667152463974949436359589931136236247929554899679139746162554183855278713574244211854227829969443151478986413333429144796664423754818256172862812877688675514142265239992529776262844329188218189254491238956497568";
		const string Part2Input = Part1Input;

		static void Main(string[] args)
		{
			// --- Day 1: Inverse Captcha ---
			// http://adventofcode.com/2017/day/1
			//
			// The captcha requires you to review a sequence of digits (your puzzle input)
			// and find the sum of all digits that match the next digit in the list.
			// The list is circular, so the digit after the last digit is the first digit in the list.
			//
			// For example:
			// - 1122 produces a sum of 3 (1 + 2) because the first digit (1) matches the second digit and the third digit (2) matches the fourth digit.
			// - 1111 produces 4 because each digit (all 1) matches the next.
			// - 1234 produces 0 because no digit matches the next.
			// - 91212129 produces 9 because the only digit that matches the next one is the last digit, 9.

			Part1(Part1Input);
			Part2(Part2Input);
			Console.ReadLine();
		}

		static void Part1(string input)
		{
			Write.ColorLine("Part 1", ConsoleColor.Yellow);

			var output = new NullOutput();
			Test.Verify(output, SolveCaptcha, "1122", 3);
			Test.Verify(output, SolveCaptcha, "1111", 4);
			Test.Verify(output, SolveCaptcha, "1234", 0);
			Test.Verify(output, SolveCaptcha, "91212129", 9);
			Console.WriteLine();

			var answer = SolveCaptcha(input);
			Write.ColorLine($"Solution: {answer}", ConsoleColor.Cyan);
		}

		static int SolveCaptcha(string input)
		{
			int sum = 0;
			var prev = ' ';
			foreach (var cur in input)
			{
				if (cur == prev)
				{
					sum += cur.ToDigitValue();
				}
				prev = cur;
			}

			if (prev == input[0])
			{
				sum += prev.ToDigitValue();
			}

			return sum;
		}

		static void Part2(string input)
		{
			/*
			Now, instead of considering the next digit, it wants you to consider the digit halfway
			around the circular list. That is, if your list contains 10 items, only include a digit
			in your sum if the digit 10/2 = 5 steps forward matches it.
			Fortunately, your list has an even number of elements.

			For example:

			- 1212 produces 6: the list contains 4 items, and all four digits match the digit 2 items ahead.
			- 1221 produces 0, because every comparison is between a 1 and a 2.
			- 123425 produces 4, because both 2s match each other, but no other digit has a match.
			- 123123 produces 12.
			- 12131415 produces 4.
			*/
			Write.ColorLine("Part 2", ConsoleColor.Yellow);
			var output = new NullOutput();
			Test.Verify<string, int>(output, SolvePart2, "1212", 6);
			Test.Verify<string, int>(output, SolvePart2, "1221", 0);
			Test.Verify<string, int>(output, SolvePart2, "123425", 4);
			Test.Verify<string, int>(output, SolvePart2, "123123", 12);
			Test.Verify<string, int>(output, SolvePart2, "12131415", 4);

			var answer = SolvePart2(input);
			Write.ColorLine($"Solution: {answer}", ConsoleColor.Cyan);

		}

		static int SolvePart2(string input)
		{
			var sum = 0;
			var distance = Math.DivRem(input.Length, 2, out int rem);

			for (int i = 0; i < input.Length; i++)
			{
				if (input.CharAtCircular(i, distance) == input[i])
				{
					sum += input[i].ToDigitValue();
				}
			}

			return sum;
		}

		static char LookAhead(string str, int start, int count)
		{
			var target = start + count;
			if (target < str.Length)
			{
				return str[target];
			}
			else
			{
				target -= str.Length;
				return str[target];
			}
		}
	}
}
