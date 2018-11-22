﻿using System;
using System.IO;
using PactNet;

namespace Consumer.Tests.AmqpPact
{
	public class MessageConsumerEventPublisherPact : IDisposable
	{
		public IMessagePactBuilder MessagePactBuilder { get; }

		public MessageConsumerEventPublisherPact()
		{
			MessagePactBuilder = new MessagePactBuilder(new PactConfig
			{
				SpecificationVersion = "2.0.0",
				LogDir = $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}logs{Path.DirectorySeparatorChar}",
				PactDir = $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}pacts{Path.DirectorySeparatorChar}"
			})
				.ServiceConsumer("Event API Message Consumer")
				.HasPactWith("Event API");
		}

		public void Dispose()
		{
			MessagePactBuilder.Build();
		}
	}
}