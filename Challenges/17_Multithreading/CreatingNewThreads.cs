/*
 Creating and starting new threads
Implement the RunThreads method in such a way that it creates and starts three new threads.
Each thread job is to print "Hello from thread with ID: X" to the console, where X is the thread's ID.



For example, after the execution of the RunThreads method, output like this 
should be printed (of course, it may have different thread IDs):

Hello from thread with ID: 13
Hello from thread with ID: 14
Hello from thread with ID: 15


Make sure to print this exact message with those words and characters.
 */
using System;

namespace Coding.Exercise
{
	public class Exercise
	{
		public static void RunThreads()
		{
			Thread thread1 = new Thread(ThreadGreetings);
			Thread thread2 = new Thread(ThreadGreetings);
			Thread thread3 = new Thread(ThreadGreetings);

			thread1.Start();
			thread2.Start();
			thread3.Start();
		}
		public static void ThreadGreetings()
		{
			Console.WriteLine($"Hello from thread with ID: {Thread.CurrentThread.ManagedThreadId}");
		}
	}
}
