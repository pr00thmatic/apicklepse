[System.Serializable]
public class CatType {
    public string verboseName;
    public TypesOfCat race;
    public Uniform speed;
    public Uniform size;

    public CatType (string verboseName, TypesOfCat race, Uniform speed, Uniform size) {
        this.verboseName = verboseName;
        this.race = race;
        this.speed = speed;
        this.size = size;
    }
}
