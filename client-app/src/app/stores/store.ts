import { createContext, useContext } from "react";
import ActivityStore from "./activityStore"
import CommonStore from "./commonStore";

interface Store{
    activityStore:ActivityStore; 
    commonStore:CommonStore; 

}

 const store:Store={
    activityStore:new ActivityStore(),
    commonStore:new CommonStore() 
}
const StoreContext=  createContext(store);


const useStore=()=>{
    return useContext(StoreContext); 
}

export{store, StoreContext, useStore};