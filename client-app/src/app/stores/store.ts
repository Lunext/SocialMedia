import { createContext, useContext } from "react";
import ActivityStore from "./activityStore"
import CommonStore from "./commonStore";
import ModalStore from "./modalStore";
import ProfileStore from "./profileStore";
import UserStore from "./userStore";

interface Store{
    activityStore:ActivityStore; 
    commonStore:CommonStore; 
    userStore: UserStore; 
    modalStore:ModalStore; 
    profileStore: ProfileStore; 

}

 const store:Store={
    activityStore:new ActivityStore(),
    commonStore:new CommonStore(), 
    userStore: new UserStore(), 
    modalStore:new ModalStore(), 
    profileStore: new ProfileStore(), 

}
const StoreContext=  createContext(store);


const useStore=()=>{
    return useContext(StoreContext); 
}

export{store, StoreContext, useStore};