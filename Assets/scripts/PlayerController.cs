using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEngine.Screen;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
 
    private const float Speed = 6f;
    
    // should be set in the inspector
    private const float MAXTiltAngle =0.15f;
    private  AudioSource explosionAudio;
    
    private Rigidbody2D _rigidbody2D;
    private float _screenWidthWorldPoints;
    private float _tiltAngle= 0.5f;
    private float _tiltThreshHold;
    




    void Start()
    {

        _rigidbody2D = GetComponent<Rigidbody2D>();
        explosionAudio = GameObject.FindGameObjectWithTag("ExplosionAudio").GetComponent<AudioSource>();
        if (Camera.main == null) return;
        Camera _camera = Camera.main;
        _screenWidthWorldPoints = _camera.aspect * _camera.orthographicSize + transform.localScale.x/2;
       

    }

   
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
                
        
            if (Input.mousePosition.x > width / 2)
            {
                transform.Translate(Vector3.right*(Speed*Time.deltaTime),Space.World);
                if (transform.rotation.z >-MAXTiltAngle)
                {
                    _tiltThreshHold = _tiltThreshHold > 0.25f ? 0 : _tiltThreshHold;
                    transform.Rotate(Vector3.forward * - _tiltAngle);
                    _tiltAngle = Mathf.Lerp(_tiltAngle, _tiltAngle + 0.05f, _tiltThreshHold);
                    _tiltThreshHold += _tiltThreshHold>=1 ?  0: 0.05f;
                }
        
                    
            }
        
            else if (Input.mousePosition.x < width / 2)
            {
                transform.Translate(Vector3.left*( Speed*Time.deltaTime),Space.World);
                if (transform.rotation.z < MAXTiltAngle)
                { 
                    _tiltThreshHold = _tiltThreshHold > 0.25f ? 0 : _tiltThreshHold;
                    transform.Rotate(Vector3.forward *  _tiltAngle);
                    _tiltAngle = Mathf.Lerp(_tiltAngle, _tiltAngle + 0.05f, _tiltThreshHold);
                    _tiltThreshHold += _tiltThreshHold>=1 ? 0 :  0.05f;
                }
                    
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // #region DepracatedMovementSystemForPC
        //
        //
        //
        //
        // var inputX = Input.GetAxisRaw("Horizontal");
        //
        //
        // _rigidbody2D.velocity = new Vector2(Speed * inputX, 0);
        //
        //
        //
        // if (inputX > 0)
        // {
        //   
        //     if (transform.rotation.z >-MAXTiltAngle)
        //     {
        //         _tiltThreshHold = _tiltThreshHold > 0.25f ? 0 : _tiltThreshHold;
        //         transform.Rotate(Vector3.forward * - _tiltAngle);
        //         _tiltAngle = Mathf.Lerp(_tiltAngle, _tiltAngle + 0.05f, _tiltThreshHold);
        //         _tiltThreshHold += _tiltThreshHold>=1 ?  0: 0.05f;
        //     }
        //   
        // }
        //
        //
        //
        //
        //
        //
        // if (inputX < 0)
        // {
        //    
        //     if (transform.rotation.z < MAXTiltAngle)
        //     { 
        //         _tiltThreshHold = _tiltThreshHold > 0.25f ? 0 : _tiltThreshHold;
        //         transform.Rotate(Vector3.forward *  _tiltAngle);
        //         _tiltAngle = Mathf.Lerp(_tiltAngle, _tiltAngle + 0.05f, _tiltThreshHold);
        //         _tiltThreshHold += _tiltThreshHold>=1 ? 0 :  0.05f;
        //     }
        //
        // }
        //
        // if (inputX == 0)
        // {
        //   
        //     transform.rotation = Quaternion.Euler(0, 0, 0);
        //
        // }
        //
        // #endregion
        //
        //
        //Declare the boundaries
     

        if (transform.position.x > _screenWidthWorldPoints)
        {
            Vector3 transformPosition = transform.position;
            transformPosition.x =  - _screenWidthWorldPoints;
            transform.position = transformPosition;
        }
        if (transform.position.x < -_screenWidthWorldPoints)
        {
            Vector3 transformPosition = transform.position;
            transformPosition.x =  + _screenWidthWorldPoints;
            transform.position = transformPosition;
        }

    


        
       
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("meteor"))
        {
            GameManager.instance.showGameOverScreen();
            GameManager.instance.increaseScore = false;
            explosionAudio.pitch = Random.Range(0.5f,1f);
            explosionAudio.Play();
            Instantiate(GameManager.instance.hitExplosion,other.ClosestPoint(transform.position),quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
          
        }
        
        
    }

    
}
