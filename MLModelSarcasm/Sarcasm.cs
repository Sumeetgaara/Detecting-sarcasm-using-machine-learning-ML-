using Microsoft.ML.Runtime.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLModelSarcasm
{

		public class Sarcasm
		{
		//[Column(ordinal: "0", name: "Label")]
		//public float Sentiment;
		//[Column(ordinal: "1")]
		//public string SentimentText;
		[Column(ordinal: "0", name: "Label")]
		public float IssueType;
		[Column(ordinal: "1")]
		public string TitleDescription;
	}

		public class SarcasmOutput
		{
		//[ColumnName("PredictedLabel")]
		//public bool Sentiment;
		[ColumnName("PredictedLabel")]
		public bool Result;
	}
	
}
