﻿using BrowserPass.BouncyCastle.util.io;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserPass.BouncyCastle.asn1
{
	public class BerOctetStringParser
		  : Asn1OctetStringParser
	{
		private readonly Asn1StreamParser _parser;

		internal BerOctetStringParser(
			Asn1StreamParser parser)
		{
			_parser = parser;
		}

		public Stream GetOctetStream()
		{
			return new ConstructedOctetStream(_parser);
		}

		public Asn1Object ToAsn1Object()
		{
			try
			{
				return new BerOctetString(Streams.ReadAll(GetOctetStream()));
			}
			catch (IOException e)
			{
				throw new Asn1ParsingException("IOException converting stream to byte array: " + e.Message, e);
			}
		}
	}
}
