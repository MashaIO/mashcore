﻿namespace Masha.Foundation.Tests
{
    using System;
    using Xunit;
    using FakeItEasy;
    using Masha.Foundation;
    using static Masha.Foundation.Core;
    using static Masha.Foundation.Tests.General;

    public class AsyncTests
    {
        [Fact]
        public async void Return_TRt__When_Asyncs_Invoked_Serially_Successful()
        {
            var svc = new AsyncService();
            var r = await Async("Sheik")
                    .Map(svc.Greet)
                    .Map(svc.GeoPoint)
                    .Map(svc.GivePriority);
            Assert.True(r.HasValue);
        }

        [Fact]
        public async void Return_TRe__When_Asyncs_Invoked_Serially_Broken()
        {
            var svc = new AsyncService();
            var r = await "Sheik"
                    .Pipe(svc.Greet)
                    .Map(svc.KickOff)
                    .Map(svc.GeoPoint)
                    .Map(svc.GivePriority);
            var result = r.Match
                (pass: i => 1, 
                fail: e => e.Exception.Message.Contains("kicked") ? -1: 0);
            Assert.Equal(-1, result);
        }

        [Fact]
        public async void Return_TRr__When_Asyncs_Starts_Tt_With_Pipe()
        {
            var svc = new AsyncService();
            var r = await "Sheik"
                    .Pipe(svc.Welcome)
                    .Map(svc.Greet)
                    .Map(svc.GeoPoint)
                    .Map(svc.GivePriority);
            var actual = r.Match
                (pass: i => 1,
                fail: e => 0);
            Assert.Equal(1, actual);
        }

        [Fact]
        public async void Return_TRr__When_Asyncs_Include_Sync()
        {
            var svc = new AsyncService();
            var r = await "Sheik"
                    .Pipe(svc.Greet)
                    .Map(svc.JustNormalHello);
            var actual = r.Match
                (pass: m => m,
                fail: e => "None");
            Assert.Equal("Your greet message is Hello, Sheik", actual);
        }

        [Fact]
        public async void Return_TRr__When_Sync_FollowedBy_Asyncs()
        {
            var svc = new AsyncService();
            var nameShouldBeProvided = Spec<string>(s => !string.IsNullOrEmpty(s));
            var r = await Result("Sheik")
                    .Map(nameShouldBeProvided, () => Error.Of(1012))
                    .Map(svc.Greet)
                    .Map(svc.JustNormalHello);
            var actual = r.Match
                (pass: m => m,
                fail: e => "None");
            Assert.Equal("Your greet message is Hello, Sheik", actual);
        }
    }
}
