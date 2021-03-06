﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace pythonIntegration {
    public class BadCodeFacts {
        private readonly ITestOutputHelper _output;

        public BadCodeFacts(ITestOutputHelper output) {
            _output = output;
        }

        public class RunMethod : BadCodeFacts {
            private readonly string[] _lines;

            public RunMethod(ITestOutputHelper output)
                : base(output) {
                var badCode = new BadCode();
                string consoleOutput = badCode.Run();
                _lines = consoleOutput.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                _output.WriteLine(consoleOutput);
            }

            [Fact]
            public void OutputShouldHaveOneLinePerLanguageWithBlankLinesInBetween() {
                IEnumerable<string> blankLines = _lines.Where((line, index) => index % 2 == 1);
                string blankString = string.Join(string.Empty, blankLines);

                Assert.Equal(string.Empty, blankString, ignoreWhiteSpaceDifferences: true);
            }

            [Fact]
            public void CSharpOutputShouldBeCorrect() {
                string cSharpLine = _lines[0];
                Assert.Equal("C# is so 1999...", cSharpLine);
            }

            [Fact]
            public void PythonOutputShouldBeCorrect() {
                string pythonLine = _lines[2];
                Assert.Equal("What?!? Python is also strongly typed?!?", pythonLine);
            }

            [Fact]
            public void JavascriptOutputShouldBeCorrect() {
                string javascriptLine = _lines[4];
                Assert.Equal("Javascript. What have we done?", javascriptLine);
            }

            [Fact]
            public void RubyOutputShouldBeCorrect() {
                string rubyLine = _lines[6];
                Assert.Equal("Once more unto the breach, dear Ruby, once more...", rubyLine);
            }
        }
    }
}
