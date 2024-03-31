/*
 Custom exception - InvalidTransactionException
Implement a custom exception class called InvalidTransactionException according to the following requirements:

It should have a public get-only TransactionData property of the TransactionData type

It should have three basic constructors that any exception should have

It should have two extra constructors - one setting the message and the TransactionData and one setting the message,
TransactionData and InnerException (please keep the parameters of the constructors in the given order)
 
 */
using System;

namespace Coding.Exercise
{


    public class TransactionData
    {
        public string Sender { get; init; }
        public string Receiver { get; init; }
        public decimal Amount { get; init; }
    }

    public class InvalidTransactionException : Exception
    {
        public TransactionData TransactionData { get; }

        public InvalidTransactionException() { }
        public InvalidTransactionException(string? message) : base(message) { }
        public InvalidTransactionException(string message, Exception ex) : base(message, ex) { }
        public InvalidTransactionException(string message, TransactionData td) : base(message)
        {
            TransactionData = td;
        }
        public InvalidTransactionException(string? message, TransactionData td, Exception ex) : base(message, ex)
        {
            TransactionData = td;
        }
    }
}
