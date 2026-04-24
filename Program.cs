using MapProgressionSimulator.Domain;
using MapProgressionSimulator.Domain.Conditions;
using MapProgressionSimulator.Engine;
using System.Net.Sockets;


var roomA = new Room("A");
var roomB = new Room("B");
var roomC = new Room("C");

//roomA.Connections.Add(new Connection(roomB)); // libre

//roomB.Connections.Add(
//    new Connection(roomC, new HasPowerCondition("Dash"))
//);
roomA.Connections.Add(new Connection(roomB, new HasPowerCondition("Dash")));
roomB.Connections.Add(new Connection(roomC));
roomB.Connections.Add(new Connection(roomA));
//roomC.Connections.Add(new Connection(roomB));

roomC.PowerGiven = "Dash";

var allRooms = new List<Room> { roomA, roomB, roomC };

var state = new PlayerState();


var explorer = new Explorer();

var reachable = explorer.Explore(allRooms, state);

var detector = new SoftLockDetector();
var locked = detector.FindSoftLocks(allRooms, reachable);

var visualizer = new GraphVisualizer();
visualizer.Print(allRooms, state, reachable);

Console.WriteLine("=== SOFT LOCK REPORT ===");

//[ACCESSIBLE] → room atteinte
//[LOCKED] → jamais atteinte
//----> → passage possible
//-X-> → passage bloqué
//(OK) → cible accessible
//(LOCKED) → cible inaccessible