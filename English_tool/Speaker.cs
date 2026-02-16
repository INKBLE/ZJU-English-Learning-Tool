using System;
using System.Collections.Generic;
using System.Text;
using System.Speech.Synthesis;


namespace English_tool
{
    public class Speaker
    {
        private SpeechSynthesizer synth;

        public Speaker()
        {
            // 初始化发音引擎
            synth = new SpeechSynthesizer();

            // 设置默认参数
            synth.Volume = 100;  // 音量 0-100
            synth.Rate = -2;      // 语速 -10 (最慢) 到 10 (最快)
        }

        // 核心功能：朗读
        public void Speak(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return;

            try
            {
                // 1. 打断之前的朗读
                // 如果用户切题很快，不要让声音排队，直接打断读新的
                synth.SpeakAsyncCancelAll();

                // 2. 异步朗读 (不会卡死界面)
                synth.SpeakAsync(text);
            }
            catch (Exception)
            {
                // 忽略发音错误，防止因为没有语音包导致程序崩溃
            }
        }

        // 停止朗读 (用于关闭窗口时)
        public void Stop()
        {
            if (synth != null)
            {
                synth.SpeakAsyncCancelAll();
            }
        }

        // 调整语速
        public void SetRate(int rate)
        {
            synth.Rate = rate;
        }
    }
}