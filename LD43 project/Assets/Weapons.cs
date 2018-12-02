using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapons : ScriptableObject {

    public string Name;
    public float Damage;
    public enum Elements {fire,water,earth }
    public Elements element;
    public enum Type {bow,sword,spear }
    public Type _type;
}
