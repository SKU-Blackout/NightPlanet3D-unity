using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GetItem : UIBase
{
    enum Images
    {
        BackGround,
        Page,
        Item,
    }

    enum Texts
    {
        ItemName,
        Description,
    }

    public override void Init()
    {
        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));
        this.itemName = Get<Text>((int)Texts.ItemName);
        this.description = Get<Text>((int)Texts.Description);
        this.itemImage = Get<Image>((int)Images.Item);
        moveEffect = GetComponent<Animation>();
    }

    private Text itemName;
    private Text description;
    private Image itemImage;
    private Animation moveEffect;

    public void SetImage(string itemName, string description, string spritePath)
    {
        if (uiDict.Count==0)
            Init();

        this.itemName.text = itemName;
        this.description.text = description;
        itemImage.sprite = GameManager.Resource.Load<Sprite>(spritePath);

        GameManager.Input.userInput -= GameManager.Input.UserInput;

        gameObject.SetActive(true);
        moveEffect.Play();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            moveEffect.Stop();
            gameObject.SetActive(false);
            GameManager.Input.userInput -= GameManager.Input.UserInput;
            GameManager.Input.userInput += GameManager.Input.UserInput;
        }
        
    }

    public void Clear()
    {
        moveEffect = null;
        itemName = null;
        description = null;
        itemImage = null;
        GameManager.Resource.Destroy(gameObject);
    }


    //문제점 : 이 클래스가 유저의 움직임을 막을 방법
    //PlayerInput함수를 InputManager에 이식
}
