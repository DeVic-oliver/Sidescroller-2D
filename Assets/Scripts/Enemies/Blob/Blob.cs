using System.Collections;
using UnityEngine;
using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Core.Classes.Static;
public class Blob : MonoBehaviour, IDamageable
{
    public bool IsAlive { get; set; }
    public int HealthPoints { get; private set; }
    [SerializeField] private BlobData blobData;
    private IMoveable blobMovements;
    public void ApplyDamage(int damageValue)
    {
        int damage = TreatNegativeNumber.GetTreatedValue(damageValue);
        if(damage >= HealthPoints)
        {
            HealthPoints = 0;
        }
        HealthPoints -= damage;
    }

    void Start()
    {
        HealthPoints = blobData.HealthPoints;
        IsAlive = true;
        InitObjects();
    }
    private void InitObjects()
    {
        blobMovements = new BlobMovement(blobData.MoveSpeed, blobData.MinMoveRangeLimit, blobData.MaxMoveRangeLimit, transform);
    }

    // Update is called once per frame
    void Update()
    {
        IsAlive = LifeStatusParser.GetLifeStatusBasedOnHealth(HealthPoints);
        blobMovements.Move(IsAlive);
    }
}
