using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundLoop : MonoBehaviour
{

    //constは値が変化しない数(定数)
    private const float MAX_OFFSET = 1f;
    private const string PROPERTY_NAME = "_MainTex";
    //Image image;

    [SerializeField] private Vector2 _offsetSpeed;
    [SerializeField] private Material _material;

    [SerializeField] private GameObject hightensionBG;
    Player player;
    float hightensionSP = 1f;
    bool isHightension = false;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        hightensionBG.SetActive(false);
    }

    // Resetメソッドは、追加したスクリプトがInspector上に表示されたときからerializeFieldが既にアタッチされているようになる。アタッチ漏れを起こさない。
    private void Reset()
    {
        // コンポーネントがアタッチされたタイミングでマテリアルを取得する
        // TryGetComponentは戻り値にコンポーネントを取得できたか確認してくれる。この場合はImageコンポネントを取得すると同時に、取得できているか確認している。
        if (TryGetComponent(out Image image))
        {
            _material = image.material;
        }
    }

    private void Update()
    {
        if(player.highTension != isHightension)
        {
            isHightension = player.highTension;
            if(isHightension)
            {
                hightensionSP = 4f;
                hightensionBG.SetActive(true);
            }
            else
            {
                hightensionSP = 1f;
                hightensionBG.SetActive(false);
            }
        }
        if (_material != null)
        {
            var x = Mathf.Repeat(Time.time * _offsetSpeed.x * hightensionSP, MAX_OFFSET);
            var y = Mathf.Repeat(Time.time * _offsetSpeed.y, MAX_OFFSET);
            var offset = new Vector2(x, y); //materialのoffsetを設定
            _material.SetTextureOffset(PROPERTY_NAME, offset);  //offsetをmaterialにセットする(変更するプロパティ名, オフセットの位置)
        }
    }

    private void OnDestroy()
    {
        // オブジェクトが破棄されるタイミングに位置をリセットする
        if (_material != null)
        {
            _material.SetTextureOffset(PROPERTY_NAME, Vector2.zero);
        }
    }
}
