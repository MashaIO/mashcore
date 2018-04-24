﻿namespace Masha.Foundation.Tests
{
    using System;
    using System.Threading.Tasks;
    using Masha.Foundation;
    using static Masha.Foundation.Core;

    public class AsyncService
    {
        public async Task<Result<string>> Greet(string name)
        {
            await Task.Delay(100);
            return $"Hello, {name}";
        }

        public async Task<Result<string>> NonGreet(string name)
        {
            await Task.Delay(100);
            return Error.Of(1000);
        }

        public async Task<Result<int>> At(string greet)
        {
            await Task.Delay(100);
            return greet.GetHashCode();
        }

        public async Task<Result<int>> GivePriority(int location)
        {
            await Task.Delay(50);
            return new Random().Next(0, System.Math.Abs(location));
        }
    }
}
