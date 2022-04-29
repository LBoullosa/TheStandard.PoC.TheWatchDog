﻿// ---------------------------------------------------------------
// Copyright (c) Raúl Lorenzo Boullosa
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using TheWatchDog.Brokers.WatchDogs;
using TheWatchDog.Models;

namespace TheWatchDog.Services.Foundations.WatchDogs
{
	public class WatchDogService : IWatchDogService
	{
		private readonly IWatchDogBroker watchDogBroker;

		public WatchDogService(IWatchDogBroker watchDogBroker) => this.watchDogBroker = watchDogBroker;

		public void RunAndListen(Action actionOnRun = null
						, Action actionDuringRun = null
						, Action actionOnSuccessfulRun = null
						, Action actionOnException = null
						, Action actionOnCancel = null)
		{
			WatchDog watchDog = new WatchDog()
				{
				Id = Guid.NewGuid()
				, State = WatchDogState.Initializating
				, ActionOnRun = actionOnRun
				, ActionDuringRun = actionDuringRun
				, ActionOnSuccessfulRun = actionOnSuccessfulRun
				, ActionOnException = actionOnException
				, ActionOnCancel = actionOnCancel
				};

			watchDogBroker.RunAndListen(watchDog);
		}

		public void Cancel()
		{
			throw new NotImplementedException();
		}

	}
}