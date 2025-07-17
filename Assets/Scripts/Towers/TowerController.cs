using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private enum TOWER_TYPE { STANDARD, RIFLE, TRACKING }

    [Header("Tower Parameters")]
    [SerializeField] private TOWER_TYPE _towerType;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _range = 5f;

    private Transform _player;
    private float _fireTimer;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.position);

        if (distance < _range)
        {
            if (_towerType == TOWER_TYPE.TRACKING)
            {
                Vector3 dir = _player.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }

            _fireTimer += Time.deltaTime;
            if (_fireTimer >= 1f / _fireRate)
            {
                Fire();
                _fireTimer = 0f;
            }
        }
    }

    void Fire()
    {
        switch (_towerType)
        {
            case TOWER_TYPE.STANDARD:
                Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
                break;

            case TOWER_TYPE.RIFLE:
                StartCoroutine(BurstFire());
                break;

            case TOWER_TYPE.TRACKING:
                Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
                break;
        }
    }

    IEnumerator BurstFire() // <- creo una coroutine per gestire lo sparo a raffica
    {
        int shots = 3;
        float delay = 0.15f;

        for (int i = 0; i < shots; i++)
        {
            Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            yield return new WaitForSeconds(delay);
        }
    }
}
