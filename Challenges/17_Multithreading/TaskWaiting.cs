/*
 Tasks & waiting
Implement the RunSimpleTask method in such a way that inside,
it runs a task and waits for its result.

This task should execute a loop 3 times, and for each iteration, 
it should:

stop for 1 second

print the "Iteration number X" to the console, where X will be 1, 2,
and then 3



Then we want to wait for the task completion, so the "The task has finished."
gets printed to the console last.
 */
using System;

namespace Coding.Exercise
{
	public class Exercise
	{
		public static void RunSimpleTask()
		{
			Console.WriteLine("Before task starting.");

			var task = Task.Run(() => {

				for (int i = 0; i < 3; i++)
				{
					Thread.Sleep(1000);
					Console.WriteLine($"Iteration number {i + 1}");
				}

			});
			task.Wait();


			Console.WriteLine("The task has finished.");
		}
	}
}
