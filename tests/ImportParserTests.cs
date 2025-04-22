using Xunit;

public class ImportParserTests
{
    [Fact]
    public void ExtractsPythonImportsCorrectly()
    {
        var pythonCode = @"
            import os
            import numpy as np
            from sklearn.model_selection import train_test_split
            from matplotlib import pyplot as plt
        ";

        var result = PythonImportParser.GetImportedModules(pythonCode);

        Assert.Contains("os", result);
        Assert.Contains("numpy", result);
        Assert.Contains("sklearn", result);
        Assert.Contains("matplotlib", result);
        Assert.DoesNotContain("pyplot", result); 
    }
}
