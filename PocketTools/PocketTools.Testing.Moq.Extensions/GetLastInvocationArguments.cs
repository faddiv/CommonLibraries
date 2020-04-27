using Moq;
using System;

namespace PocketTools.Testing.Moq.Extensions
{
    partial class MockExtensions {
	    public static void GetLastInvocationArguments<T, TParameter1, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TReturn> func
                , out TParameter1 parameter1
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
        }

	    public static void GetLastInvocationArguments<T, TParameter1, TParameter2, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TParameter2, TReturn> func
                , out TParameter1 parameter1
                , out TParameter2 parameter2
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                , typeof(TParameter2)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
        }

	    public static void GetLastInvocationArguments<T, TParameter1, TParameter2, TParameter3, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TParameter2, TParameter3, TReturn> func
                , out TParameter1 parameter1
                , out TParameter2 parameter2
                , out TParameter3 parameter3
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                , typeof(TParameter2)
                , typeof(TParameter3)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
            parameter3 = (TParameter3)lastInvocation[2];
        }

	    public static void GetLastInvocationArguments<T, TParameter1, TParameter2, TParameter3, TParameter4, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TParameter2, TParameter3, TParameter4, TReturn> func
                , out TParameter1 parameter1
                , out TParameter2 parameter2
                , out TParameter3 parameter3
                , out TParameter4 parameter4
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                , typeof(TParameter2)
                , typeof(TParameter3)
                , typeof(TParameter4)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
            parameter3 = (TParameter3)lastInvocation[2];
            parameter4 = (TParameter4)lastInvocation[3];
        }

	    public static void GetLastInvocationArguments<T, TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TReturn> func
                , out TParameter1 parameter1
                , out TParameter2 parameter2
                , out TParameter3 parameter3
                , out TParameter4 parameter4
                , out TParameter5 parameter5
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                , typeof(TParameter2)
                , typeof(TParameter3)
                , typeof(TParameter4)
                , typeof(TParameter5)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
            parameter3 = (TParameter3)lastInvocation[2];
            parameter4 = (TParameter4)lastInvocation[3];
            parameter5 = (TParameter5)lastInvocation[4];
        }

	    public static void GetLastInvocationArguments<T, TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TReturn> func
                , out TParameter1 parameter1
                , out TParameter2 parameter2
                , out TParameter3 parameter3
                , out TParameter4 parameter4
                , out TParameter5 parameter5
                , out TParameter6 parameter6
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                , typeof(TParameter2)
                , typeof(TParameter3)
                , typeof(TParameter4)
                , typeof(TParameter5)
                , typeof(TParameter6)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
            parameter3 = (TParameter3)lastInvocation[2];
            parameter4 = (TParameter4)lastInvocation[3];
            parameter5 = (TParameter5)lastInvocation[4];
            parameter6 = (TParameter6)lastInvocation[5];
        }

	    public static void GetLastInvocationArguments<T, TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TReturn> func
                , out TParameter1 parameter1
                , out TParameter2 parameter2
                , out TParameter3 parameter3
                , out TParameter4 parameter4
                , out TParameter5 parameter5
                , out TParameter6 parameter6
                , out TParameter7 parameter7
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                , typeof(TParameter2)
                , typeof(TParameter3)
                , typeof(TParameter4)
                , typeof(TParameter5)
                , typeof(TParameter6)
                , typeof(TParameter7)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
            parameter3 = (TParameter3)lastInvocation[2];
            parameter4 = (TParameter4)lastInvocation[3];
            parameter5 = (TParameter5)lastInvocation[4];
            parameter6 = (TParameter6)lastInvocation[5];
            parameter7 = (TParameter7)lastInvocation[6];
        }

	    public static void GetLastInvocationArguments<T, TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TReturn> func
                , out TParameter1 parameter1
                , out TParameter2 parameter2
                , out TParameter3 parameter3
                , out TParameter4 parameter4
                , out TParameter5 parameter5
                , out TParameter6 parameter6
                , out TParameter7 parameter7
                , out TParameter8 parameter8
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                , typeof(TParameter2)
                , typeof(TParameter3)
                , typeof(TParameter4)
                , typeof(TParameter5)
                , typeof(TParameter6)
                , typeof(TParameter7)
                , typeof(TParameter8)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
            parameter3 = (TParameter3)lastInvocation[2];
            parameter4 = (TParameter4)lastInvocation[3];
            parameter5 = (TParameter5)lastInvocation[4];
            parameter6 = (TParameter6)lastInvocation[5];
            parameter7 = (TParameter7)lastInvocation[6];
            parameter8 = (TParameter8)lastInvocation[7];
        }

	    public static void GetLastInvocationArguments<T, TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TReturn> func
                , out TParameter1 parameter1
                , out TParameter2 parameter2
                , out TParameter3 parameter3
                , out TParameter4 parameter4
                , out TParameter5 parameter5
                , out TParameter6 parameter6
                , out TParameter7 parameter7
                , out TParameter8 parameter8
                , out TParameter9 parameter9
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                , typeof(TParameter2)
                , typeof(TParameter3)
                , typeof(TParameter4)
                , typeof(TParameter5)
                , typeof(TParameter6)
                , typeof(TParameter7)
                , typeof(TParameter8)
                , typeof(TParameter9)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
            parameter3 = (TParameter3)lastInvocation[2];
            parameter4 = (TParameter4)lastInvocation[3];
            parameter5 = (TParameter5)lastInvocation[4];
            parameter6 = (TParameter6)lastInvocation[5];
            parameter7 = (TParameter7)lastInvocation[6];
            parameter8 = (TParameter8)lastInvocation[7];
            parameter9 = (TParameter9)lastInvocation[8];
        }

	    public static void GetLastInvocationArguments<T, TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TParameter10, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TParameter10, TReturn> func
                , out TParameter1 parameter1
                , out TParameter2 parameter2
                , out TParameter3 parameter3
                , out TParameter4 parameter4
                , out TParameter5 parameter5
                , out TParameter6 parameter6
                , out TParameter7 parameter7
                , out TParameter8 parameter8
                , out TParameter9 parameter9
                , out TParameter10 parameter10
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                , typeof(TParameter2)
                , typeof(TParameter3)
                , typeof(TParameter4)
                , typeof(TParameter5)
                , typeof(TParameter6)
                , typeof(TParameter7)
                , typeof(TParameter8)
                , typeof(TParameter9)
                , typeof(TParameter10)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
            parameter3 = (TParameter3)lastInvocation[2];
            parameter4 = (TParameter4)lastInvocation[3];
            parameter5 = (TParameter5)lastInvocation[4];
            parameter6 = (TParameter6)lastInvocation[5];
            parameter7 = (TParameter7)lastInvocation[6];
            parameter8 = (TParameter8)lastInvocation[7];
            parameter9 = (TParameter9)lastInvocation[8];
            parameter10 = (TParameter10)lastInvocation[9];
        }

	    public static void GetLastInvocationArguments<T, TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TParameter10, TParameter11, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TParameter10, TParameter11, TReturn> func
                , out TParameter1 parameter1
                , out TParameter2 parameter2
                , out TParameter3 parameter3
                , out TParameter4 parameter4
                , out TParameter5 parameter5
                , out TParameter6 parameter6
                , out TParameter7 parameter7
                , out TParameter8 parameter8
                , out TParameter9 parameter9
                , out TParameter10 parameter10
                , out TParameter11 parameter11
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                , typeof(TParameter2)
                , typeof(TParameter3)
                , typeof(TParameter4)
                , typeof(TParameter5)
                , typeof(TParameter6)
                , typeof(TParameter7)
                , typeof(TParameter8)
                , typeof(TParameter9)
                , typeof(TParameter10)
                , typeof(TParameter11)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
            parameter3 = (TParameter3)lastInvocation[2];
            parameter4 = (TParameter4)lastInvocation[3];
            parameter5 = (TParameter5)lastInvocation[4];
            parameter6 = (TParameter6)lastInvocation[5];
            parameter7 = (TParameter7)lastInvocation[6];
            parameter8 = (TParameter8)lastInvocation[7];
            parameter9 = (TParameter9)lastInvocation[8];
            parameter10 = (TParameter10)lastInvocation[9];
            parameter11 = (TParameter11)lastInvocation[10];
        }

	    public static void GetLastInvocationArguments<T, TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TParameter10, TParameter11, TParameter12, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TParameter10, TParameter11, TParameter12, TReturn> func
                , out TParameter1 parameter1
                , out TParameter2 parameter2
                , out TParameter3 parameter3
                , out TParameter4 parameter4
                , out TParameter5 parameter5
                , out TParameter6 parameter6
                , out TParameter7 parameter7
                , out TParameter8 parameter8
                , out TParameter9 parameter9
                , out TParameter10 parameter10
                , out TParameter11 parameter11
                , out TParameter12 parameter12
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                , typeof(TParameter2)
                , typeof(TParameter3)
                , typeof(TParameter4)
                , typeof(TParameter5)
                , typeof(TParameter6)
                , typeof(TParameter7)
                , typeof(TParameter8)
                , typeof(TParameter9)
                , typeof(TParameter10)
                , typeof(TParameter11)
                , typeof(TParameter12)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
            parameter3 = (TParameter3)lastInvocation[2];
            parameter4 = (TParameter4)lastInvocation[3];
            parameter5 = (TParameter5)lastInvocation[4];
            parameter6 = (TParameter6)lastInvocation[5];
            parameter7 = (TParameter7)lastInvocation[6];
            parameter8 = (TParameter8)lastInvocation[7];
            parameter9 = (TParameter9)lastInvocation[8];
            parameter10 = (TParameter10)lastInvocation[9];
            parameter11 = (TParameter11)lastInvocation[10];
            parameter12 = (TParameter12)lastInvocation[11];
        }

	    public static void GetLastInvocationArguments<T, TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TParameter10, TParameter11, TParameter12, TParameter13, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TParameter10, TParameter11, TParameter12, TParameter13, TReturn> func
                , out TParameter1 parameter1
                , out TParameter2 parameter2
                , out TParameter3 parameter3
                , out TParameter4 parameter4
                , out TParameter5 parameter5
                , out TParameter6 parameter6
                , out TParameter7 parameter7
                , out TParameter8 parameter8
                , out TParameter9 parameter9
                , out TParameter10 parameter10
                , out TParameter11 parameter11
                , out TParameter12 parameter12
                , out TParameter13 parameter13
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                , typeof(TParameter2)
                , typeof(TParameter3)
                , typeof(TParameter4)
                , typeof(TParameter5)
                , typeof(TParameter6)
                , typeof(TParameter7)
                , typeof(TParameter8)
                , typeof(TParameter9)
                , typeof(TParameter10)
                , typeof(TParameter11)
                , typeof(TParameter12)
                , typeof(TParameter13)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
            parameter3 = (TParameter3)lastInvocation[2];
            parameter4 = (TParameter4)lastInvocation[3];
            parameter5 = (TParameter5)lastInvocation[4];
            parameter6 = (TParameter6)lastInvocation[5];
            parameter7 = (TParameter7)lastInvocation[6];
            parameter8 = (TParameter8)lastInvocation[7];
            parameter9 = (TParameter9)lastInvocation[8];
            parameter10 = (TParameter10)lastInvocation[9];
            parameter11 = (TParameter11)lastInvocation[10];
            parameter12 = (TParameter12)lastInvocation[11];
            parameter13 = (TParameter13)lastInvocation[12];
        }

	    public static void GetLastInvocationArguments<T, TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TParameter10, TParameter11, TParameter12, TParameter13, TParameter14, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TParameter10, TParameter11, TParameter12, TParameter13, TParameter14, TReturn> func
                , out TParameter1 parameter1
                , out TParameter2 parameter2
                , out TParameter3 parameter3
                , out TParameter4 parameter4
                , out TParameter5 parameter5
                , out TParameter6 parameter6
                , out TParameter7 parameter7
                , out TParameter8 parameter8
                , out TParameter9 parameter9
                , out TParameter10 parameter10
                , out TParameter11 parameter11
                , out TParameter12 parameter12
                , out TParameter13 parameter13
                , out TParameter14 parameter14
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                , typeof(TParameter2)
                , typeof(TParameter3)
                , typeof(TParameter4)
                , typeof(TParameter5)
                , typeof(TParameter6)
                , typeof(TParameter7)
                , typeof(TParameter8)
                , typeof(TParameter9)
                , typeof(TParameter10)
                , typeof(TParameter11)
                , typeof(TParameter12)
                , typeof(TParameter13)
                , typeof(TParameter14)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
            parameter3 = (TParameter3)lastInvocation[2];
            parameter4 = (TParameter4)lastInvocation[3];
            parameter5 = (TParameter5)lastInvocation[4];
            parameter6 = (TParameter6)lastInvocation[5];
            parameter7 = (TParameter7)lastInvocation[6];
            parameter8 = (TParameter8)lastInvocation[7];
            parameter9 = (TParameter9)lastInvocation[8];
            parameter10 = (TParameter10)lastInvocation[9];
            parameter11 = (TParameter11)lastInvocation[10];
            parameter12 = (TParameter12)lastInvocation[11];
            parameter13 = (TParameter13)lastInvocation[12];
            parameter14 = (TParameter14)lastInvocation[13];
        }

	    public static void GetLastInvocationArguments<T, TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TParameter10, TParameter11, TParameter12, TParameter13, TParameter14, TParameter15, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TParameter10, TParameter11, TParameter12, TParameter13, TParameter14, TParameter15, TReturn> func
                , out TParameter1 parameter1
                , out TParameter2 parameter2
                , out TParameter3 parameter3
                , out TParameter4 parameter4
                , out TParameter5 parameter5
                , out TParameter6 parameter6
                , out TParameter7 parameter7
                , out TParameter8 parameter8
                , out TParameter9 parameter9
                , out TParameter10 parameter10
                , out TParameter11 parameter11
                , out TParameter12 parameter12
                , out TParameter13 parameter13
                , out TParameter14 parameter14
                , out TParameter15 parameter15
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                , typeof(TParameter2)
                , typeof(TParameter3)
                , typeof(TParameter4)
                , typeof(TParameter5)
                , typeof(TParameter6)
                , typeof(TParameter7)
                , typeof(TParameter8)
                , typeof(TParameter9)
                , typeof(TParameter10)
                , typeof(TParameter11)
                , typeof(TParameter12)
                , typeof(TParameter13)
                , typeof(TParameter14)
                , typeof(TParameter15)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
            parameter3 = (TParameter3)lastInvocation[2];
            parameter4 = (TParameter4)lastInvocation[3];
            parameter5 = (TParameter5)lastInvocation[4];
            parameter6 = (TParameter6)lastInvocation[5];
            parameter7 = (TParameter7)lastInvocation[6];
            parameter8 = (TParameter8)lastInvocation[7];
            parameter9 = (TParameter9)lastInvocation[8];
            parameter10 = (TParameter10)lastInvocation[9];
            parameter11 = (TParameter11)lastInvocation[10];
            parameter12 = (TParameter12)lastInvocation[11];
            parameter13 = (TParameter13)lastInvocation[12];
            parameter14 = (TParameter14)lastInvocation[13];
            parameter15 = (TParameter15)lastInvocation[14];
        }

	    public static void GetLastInvocationArguments<T, TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TParameter10, TParameter11, TParameter12, TParameter13, TParameter14, TParameter15, TParameter16, TReturn>(
                this Mock<T> mock, 
                Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, TParameter6, TParameter7, TParameter8, TParameter9, TParameter10, TParameter11, TParameter12, TParameter13, TParameter14, TParameter15, TParameter16, TReturn> func
                , out TParameter1 parameter1
                , out TParameter2 parameter2
                , out TParameter3 parameter3
                , out TParameter4 parameter4
                , out TParameter5 parameter5
                , out TParameter6 parameter6
                , out TParameter7 parameter7
                , out TParameter8 parameter8
                , out TParameter9 parameter9
                , out TParameter10 parameter10
                , out TParameter11 parameter11
                , out TParameter12 parameter12
                , out TParameter13 parameter13
                , out TParameter14 parameter14
                , out TParameter15 parameter15
                , out TParameter16 parameter16
                )
                 where T : class
        {
            VerifyInvocation(typeof(T), func.Method
                , typeof(TParameter1)
                , typeof(TParameter2)
                , typeof(TParameter3)
                , typeof(TParameter4)
                , typeof(TParameter5)
                , typeof(TParameter6)
                , typeof(TParameter7)
                , typeof(TParameter8)
                , typeof(TParameter9)
                , typeof(TParameter10)
                , typeof(TParameter11)
                , typeof(TParameter12)
                , typeof(TParameter13)
                , typeof(TParameter14)
                , typeof(TParameter15)
                , typeof(TParameter16)
                );
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
            parameter3 = (TParameter3)lastInvocation[2];
            parameter4 = (TParameter4)lastInvocation[3];
            parameter5 = (TParameter5)lastInvocation[4];
            parameter6 = (TParameter6)lastInvocation[5];
            parameter7 = (TParameter7)lastInvocation[6];
            parameter8 = (TParameter8)lastInvocation[7];
            parameter9 = (TParameter9)lastInvocation[8];
            parameter10 = (TParameter10)lastInvocation[9];
            parameter11 = (TParameter11)lastInvocation[10];
            parameter12 = (TParameter12)lastInvocation[11];
            parameter13 = (TParameter13)lastInvocation[12];
            parameter14 = (TParameter14)lastInvocation[13];
            parameter15 = (TParameter15)lastInvocation[14];
            parameter16 = (TParameter16)lastInvocation[15];
        }

    }
}