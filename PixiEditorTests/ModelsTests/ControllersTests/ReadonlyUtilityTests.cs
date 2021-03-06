﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using PixiEditor.Models.Controllers;
using PixiEditor.Models.Position;
using PixiEditor.Models.Tools;
using Xunit;

namespace PixiEditorTests.ModelsTests.ControllersTests
{
    public class ReadonlyUtilityTests
    {
        [Fact]
        public void TestThatExecuteToolExecutesTool()
        {
            bool toolUsed = false;

            ReadonlyToolUtility util = new ReadonlyToolUtility();
            util.ExecuteTool(new[]{new Coordinates(0,0)}, new TestReadonlyTool(() => toolUsed = true));
            Assert.True(toolUsed);
        }

    }

    public class TestReadonlyTool : ReadonlyTool
    {
        public Action ToolAction { get; set; }
        public TestReadonlyTool(Action toolAction)
        {
            ToolAction = toolAction;
        }

        public override ToolType ToolType => ToolType.Select;
        public override void Use(Coordinates[] pixels)
        {
            ToolAction();
        }
    }
}
