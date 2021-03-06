﻿using StreamDeckLib;
using StreamDeckLib.Messages;
using System.Dynamic;
using System.Threading.Tasks;

namespace SamplePlugin
{
	internal class MySamplePlugin : BaseStreamDeckPlugin
	{

		// Cheer 200 kevin_downs Jan 11, 2019
		// Cheer 401 cpayette Jan 15, 2019
		// Cheer 2501 themikejolley Jan 15, 2019
		// Cheer 100 wolfgang_blitz Jan 15, 2019
		// Cheer 157 jongalloway Jan 15, 2019
		// Cheer 100 johanb Jan 15, 2019
		// Cheer 400 faniereynders Jan 15, 2019
		// Cheer 100 TomMcQ Jan 15, 2019
		// Cheer 361 Crazy240sx Jan 15, 2019
		// Cheer 600 yarrgh Jan 15, 2019
		// Cheer 1030 kulu83 Jan 15, 2019
		// Cheer 2500 Auth0Bobby Jan 15, 2019

		private static int _Counter = 0;

		public override async Task OnKeyUp(StreamDeckEventPayload args)
		{
			_Counter++;
			await Manager.SetTitleAsync(args.context, _Counter.ToString());

            if (_Counter % 10 == 0)
            {
                await Manager.ShowAlertAsync(args.context);
            }
            else if (_Counter % 15 == 0)
            {
                await Manager.OpenUrlAsync(args.context, "https://www.bing.com");
            }
            else if (_Counter % 3 == 0)
            {
                await Manager.ShowOkAsync(args.context);
            } 
        }

        public override async Task OnWillAppear(StreamDeckEventPayload args)
        {
            if(args.payload!= null && args.payload.settings != null && args.payload.settings.counter != null)
            {
                _Counter = args.payload.settings.counter;
            }
            await Manager.SetTitleAsync(args.context, _Counter.ToString());
        }

        public override async Task OnWillDisappear(StreamDeckEventPayload args)
        {
            dynamic settings = new ExpandoObject();
            settings.counter = _Counter;
            await Manager.SetSettingsAsync(args.context, settings);
        }
    }
}