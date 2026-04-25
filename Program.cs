using MapProgressionSimulator.Domain;
using MapProgressionSimulator.Domain.Conditions;
using MapProgressionSimulator.Engine;
using MapProgressionSimulator.Engine.Dragéomite;
using MapProgressionSimulator.Models.Dragéomite;
using System.Net.Sockets;

////[ACCESSIBLE] → room atteinte
////[LOCKED] → jamais atteinte
////----> → passage possible
////-X-> → passage bloqué
////(OK) → cible accessible
////(LOCKED) → cible inaccessible

//var roomA = new Room("A");
//var roomB = new Room("B");
//var roomC = new Room("C");

////roomA.Connections.Add(new Connection(roomB)); // libre

////roomB.Connections.Add(
////    new Connection(roomC, new HasPowerCondition("Dash"))
////);
//roomA.Connections.Add(new Connection(roomB, new HasPowerCondition("Dash")));
//roomB.Connections.Add(new Connection(roomC));
//roomB.Connections.Add(new Connection(roomA));
////roomC.Connections.Add(new Connection(roomB));

//roomC.PowerGiven = "Dash";

//var allRooms = new List<Room> { roomA, roomB, roomC };

//var state = new PlayerState();


//var explorer = new Explorer();

//var reachable = explorer.Explore(allRooms, state);

//var detector = new SoftLockDetector();
//var locked = detector.FindSoftLocks(allRooms, reachable);

//var visualizer = new GraphVisualizer();
//visualizer.Print(allRooms, state, reachable);

//Console.WriteLine("=== SOFT LOCK REPORT ===");

var roomA = new Case { Name = "A" };
var roomB = new Case { Name = "B" };
var roomC = new Case { Name = "C" };
var roomD = new Case { Name = "D" };

roomA.AdjacentCases["Right"] = roomB;
roomB.AdjacentCases["Left"] = roomA;

roomB.AdjacentCases["Right"] = roomC;
roomC.AdjacentCases["Left"] = roomB;

roomB.AdjacentCases["Bottom"] = roomD;
roomD.AdjacentCases["Top"] = roomB;

roomC.AdjacentCases["Right"] = null;

var rooms = new Dictionary<string, Case>
{
    { "A", roomA },
    { "B", roomB },
    { "C", roomC },
    { "D", roomD },
};

//var validator = new MapValidator();

//bool isValid = validator.IsMapValid(rooms, roomA);

//Console.WriteLine($"Map valide : {isValid}");

var printer = new MapPrinter();
printer.Print(rooms, roomA);

var printer2D = new MapPrinter2D();
printer2D.Print(rooms, roomA);

var validator = new MapValidator();
bool isBossReachable = validator.IsBossReachable(roomA, roomD);
Console.WriteLine($"Boss reachable : {isBossReachable}");