using Swapper;

var builder = new Builder()
    .Shuffle("123456")
    .Stack(0).Swap(1)
    .Stack(0).Mirror()
    .Stack(0).Shuffle()
    .Stacks().Mirror()
    .Stacks().ForEach(stack => stack.Mirror())
    .Bands().ForEach(band => band.Mirror())
    .Band(0).Swap(1)
    .Band(0).Mirror()
    .Bands().Mirror()
    .Rotate();
        
Grid starter = "105000020000306500004106000010000205";
Console.WriteLine(builder.Apply(starter, new Random(1234)).ToString());

Grid solution = "145623623451316542254136562314431265"; 
Console.WriteLine(builder.Apply(solution, new Random(1234)).ToString());