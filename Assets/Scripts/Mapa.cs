using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mapa : MonoBehaviour {

	public GameObject mapa1;
	public GameObject mapa2;
	public GameObject mapa3;
	public GameObject mapa4;
	public GameObject mapa5;
	public GameObject mapa6;
	public GameObject mapa7;
	public GameObject mapa8;
	public GameObject mapa9;
	public GameObject mapa10;
	public GameObject mapmu;
	public GameObject key;
	public Text level;
	public int mapp = 1;

	public void levelAct(){
		DataTravel lveli = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		mapp += 1;
		if (mapp == 2) {
			level.text = "Nivel 2";
			lveli.lvl2 = 1;
		}else if(mapp == 3){
			level.text = "Nivel 3";
			lveli.lvl3 = 1;
		}else if(mapp == 4){
			level.text = "Nivel 4";
			lveli.lvl4 = 1;
		}else if(mapp == 5){
			level.text = "Nivel 5";
			lveli.lvl5 = 1;
		}else if(mapp == 6){
			level.text = "Nivel 6";
			lveli.lvl6 = 1;
		}else if(mapp == 7){
			level.text = "Nivel 7";
			lveli.lvl7 = 1;
		}else if(mapp == 8){
			level.text = "Nivel 8";
			lveli.lvl8 = 1;
		}else if(mapp == 9){
			level.text = "Nivel 9";
			lveli.lvl9 = 1;
		}else if(mapp == 10){
			level.text = "Nivel 10";
			lveli.lvl10 = 1;
		}else if(mapp == 11){
			level.text = "Tank King";
		}
		GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("levels");
	}

	public void next(){
		if(mapp == 2){
			map2();
		}else if(mapp == 3){
			map3();
		}else if(mapp == 4){
			map4();
		}else if(mapp == 5){
			map5();
		}else if(mapp == 6){
			map6();
		}else if(mapp == 7){
			map7();
		}else if(mapp == 8){
			map8();
		}else if(mapp == 9){
			map9();
		}else if(mapp == 10){
			map10();
		}
	}

	public void map1(){
		Instantiate (mapa1, new Vector3 (0, 0, 0), Quaternion.identity);
		mapp = 1;
	}

	public void map2(){
		Instantiate (mapa2, new Vector3 (0, 0, 0), Quaternion.identity);
		mapp = 2;
	}

	public void map3(){
		Instantiate (mapa3, new Vector3 (0, 0, 0), Quaternion.identity);
		mapp = 3;
	}

	public void map4(){
		Instantiate (mapa4, new Vector3 (0, 0, 0), Quaternion.identity);
		mapp = 4;
	}

	public void map5(){
		Instantiate (mapa5, new Vector3 (0, 0, 0), Quaternion.identity);
		mapp = 5;
	}

	public void map6(){
		Instantiate (mapa6, new Vector3 (0, 0, 0), Quaternion.identity);
		mapp = 6;
	}

	public void map7(){
		Instantiate (mapa7, new Vector3 (0, 0, 0), Quaternion.identity);
		mapp = 7;
	}

	public void map8(){
		Instantiate (mapa8, new Vector3 (0, 0, 0), Quaternion.identity);
		mapp = 8;
	}

	public void map9(){
		Instantiate (mapa9, new Vector3 (0, 0, 0), Quaternion.identity);
		mapp = 9;
	}

	public void map10(){
		Instantiate (mapa10, new Vector3 (0, 0, 0), Quaternion.identity);
		mapp = 10;
	}

	public void camerita(){
		if (mapp == 1) {
			Respawn ress = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Respawn>();
			ress.camx = -1.57f;
			ress.camy = -5.11f;
		}else if (mapp == 2) {
			Respawn ress = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Respawn>();
			ress.camx = -1.57f;
			ress.camy = 1.55f;
		}else if (mapp == 3) {
			Respawn ress = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Respawn>();
			ress.camx = 10.26f;
			ress.camy = -5.11f;
		}else if (mapp == 4) {
			Respawn ress = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Respawn>();
			ress.camx = 10.26f;
			ress.camy = -3.55f;
		}else if (mapp == 5) {
			Respawn ress = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Respawn>();
			ress.camx = -1.57f;
			ress.camy = 1.55f;
		}else if (mapp == 6) {
			Respawn ress = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Respawn>();
			ress.camx = -0.325f;
			ress.camy = 1.55f;
		}else if (mapp == 7) {
			Respawn ress = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Respawn>();
			ress.camx = -1.57f;
			ress.camy = -3.55f;
		}else if (mapp == 8) {
			Respawn ress = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Respawn>();
			ress.camx = 10.26f;
			ress.camy = 1.55f;
		}else if (mapp == 9) {
			Respawn ress = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Respawn>();
			ress.camx = -1.57f;
			ress.camy = -7.12f;
		}else if (mapp == 10) {
			Respawn ress = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Respawn>();
			ress.camx = 5.91f;
			ress.camy = -1.99f;
		}
	}

	public void destruMa(){
		mapmu = GameObject.FindGameObjectWithTag ("Mapamu");
		key = GameObject.FindGameObjectWithTag ("Key");
		Destroy(mapmu);
		Destroy(key);
	}
}
