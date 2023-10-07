using System.Collections;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 20;
    private const float ShotAngle = 35f;
    private const float ExtraAngle = 5.0f;
    private const float AkimboDistance = .4f;
    private Vector3 _akimboVector1;
    private Vector3 _akimboVector2;

    private bool _allowFire;
    private bool _leftFire;
    private bool _rightFire;

    // Start is called before the first frame update
    void Start()
    {
        // initial state
        _allowFire = true;
        _akimboVector1 = new Vector3(AkimboDistance / 2, 1.6f, 0f);
        _akimboVector2 = new Vector3(-AkimboDistance / 2, 1.6f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        _leftFire = Input.GetKey(KeyCode.Z) && _allowFire;
        _rightFire = Input.GetKey(KeyCode.X) && _allowFire;
        var shooting = _leftFire || _rightFire;

        if(shooting && _allowFire)
        {
            StartCoroutine(nameof(FireWeapon));
        }
    }

    private IEnumerator FireWeapon()
    {
        _allowFire = false;
        Vector3 playerPosition = transform.position;
        var leftFire = _leftFire ? 1 : 0;
        var rightFire = _rightFire ? 1 : 0;
        // TODO rotation shall be fluent
        // TODO move weapon settings to initializer
        Quaternion bulletRotation = Quaternion.Euler(0f, 0f, (leftFire - rightFire) * ShotAngle);
        var extraRotation = Quaternion.Euler(0f, 0f, (leftFire - rightFire) * ExtraAngle);
        var leftRotation = leftFire > 0 ? extraRotation : Quaternion.identity;
        var rightRotation = rightFire > 0 ? extraRotation : Quaternion.identity;
        Instantiate(projectilePrefab, playerPosition + _akimboVector1, bulletRotation * rightRotation);
        Instantiate(projectilePrefab, playerPosition + _akimboVector2, bulletRotation * leftRotation);
        yield return new WaitForSeconds(1 / fireRate);
        _allowFire = true;
    }
}
