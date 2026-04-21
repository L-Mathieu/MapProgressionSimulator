using MapProgressionSimulator.Domain;
using MapProgressionSimulator.Engine;
using MapProgressionSimulator.Domain.Conditions;


var roomA = new Room("A");
var roomB = new Room("B");
var roomC = new Room("C");

//roomA.Connections.Add(new Connection(roomB)); // libre

//roomB.Connections.Add(
//    new Connection(roomC, new HasPowerCondition("Dash"))
//);
roomA.Connections.Add(new Connection(roomB, new HasPowerCondition("Dash")));
roomB.Connections.Add(new Connection(roomC));
//roomC.Connections.Add(new Connection(roomA));

roomC.PowerGiven = "Dash";

var allRooms = new List<Room> { roomA, roomB, roomC };

var state = new PlayerState();

var explorer = new Explorer();

var reachable = explorer.Explore(allRooms, state);

var detector = new SoftLockDetector();
var locked = detector.FindSoftLocks(allRooms, reachable);

Console.WriteLine("=== SOFT LOCK REPORT ===");

if (locked.Count == 0)
{
    Console.WriteLine("OK: no soft-lock detected");
}
else
{
    Console.WriteLine("Locked rooms:");
    foreach (var r in locked)
        Console.WriteLine(r);
}

var result = explorer.Explore(allRooms, state);

Console.WriteLine("Rooms accessibles :");

foreach (var r in result)
{
    Console.WriteLine(r);
}