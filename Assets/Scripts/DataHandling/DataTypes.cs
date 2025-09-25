using System;
using System.Collections.Generic;

[Serializable]
public class Puzzle {
    public string id;
    public bool completed;
    public int points;
}

[Serializable]
public class Pack {
    public string id;
    public List<Puzzle> puzzles;
}

[Serializable]
public class PackList {
    public List<Pack> packs;
}