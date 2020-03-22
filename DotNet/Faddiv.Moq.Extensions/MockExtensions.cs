using Moq;
using System;
using System.Linq;
using System.Reflection;

namespace Faddiv.Moq.Extensions
{
    public static class MockExtensions
    {
        public static void GetLastInvocationArguments<T, TParameter1, TReturn>(
            this Mock<T> mock, 
            Func<TParameter1, TReturn> func,
            out TParameter1 parameter1)
             where T : class
        {
            VerifyInvocation(typeof(T), func.Method, 
                typeof(TParameter1));
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
        }

        public static void GetLastInvocationArguments<T, TParameter1,
            TParameter2, TReturn>(
            this Mock<T> mock,
            Func<TParameter1, TParameter2, TReturn> func,
            out TParameter1 parameter1,
            out TParameter2 parameter2)
             where T : class
        {
            VerifyInvocation(typeof(T), func.Method, 
                typeof(TParameter1), typeof(TParameter2));
            var lastInvocation = mock.LastInvocation(func.Method)
                .Arguments;
            parameter1 = (TParameter1)lastInvocation[0];
            parameter2 = (TParameter2)lastInvocation[1];
        }

        private static IInvocation LastInvocation(
            this Mock mock, 
            MethodInfo methodInfo)
        {
            return mock.Invocations
                .Where(invocation => IsMatch(invocation, methodInfo))
                .Last();
        }

        private static bool IsMatch(IInvocation invocation, MethodInfo methodInfo)
        {
            var current = invocation.Method;
            if (current.Name != methodInfo.Name)
                return false;
            if (current.ReturnType != methodInfo.ReturnType)
                return false;
            var currentParameters = current.GetParameters();
            var expectedParameters = methodInfo.GetParameters();
            if (currentParameters.Length != expectedParameters.Length)
                return false;
            for (int i = 0; i < expectedParameters.Length; i++)
            {
                if(currentParameters[i].ParameterType != expectedParameters[i].ParameterType)
                {
                    return false;
                }
            }
            return true;
        }

        private static void VerifyInvocation(
            Type mockType, 
            MethodInfo methodInfo,
            params Type[] parameterTypes)
        {
            if (!methodInfo.DeclaringType.GetInterfaces().Any(t => t == mockType))
            {
                throw new ArgumentException($"The given method '{methodInfo.Name}' doesn't match with the mock declared type '{mockType}'.");
            }
            var expectedParameters = methodInfo.GetParameters();
            if (expectedParameters.Length != parameterTypes.Length) 
                throw new ArgumentException($"Parameter type mismatch. Expected {expectedParameters.Length} parameter(s) but got {parameterTypes.Length}.");
            for (int i = 0; i < expectedParameters.Length; i++)
            {
                var expectedParameterType = expectedParameters[i].ParameterType;
                var actualParameterType = parameterTypes[i];
                if (actualParameterType != expectedParameterType)
                {
                    throw new ArgumentException($"Parameter type mismatch. Expected parameter type at {i} is {expectedParameterType.Name} but got {actualParameterType.Name}.");
                }
            }
            return;
        }
    }
}
