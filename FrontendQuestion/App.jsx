import React from 'react';

const styles={
  headerStyle:{
    fontFamily: 'Arial',
    fontSize:'25px',
    fontWeight:'bold'
  },
  buttonStyle: {
    boxShadow: 'rgb(164, 226, 113) 0px 1px 0px 0px inset',
    background: 'linear-gradient(rgb(137, 196, 3) 5%, rgb(119, 168, 9) 100%) rgb(137, 196, 3)',
    borderRadius: '6px',
    border: '1px solid rgb(116, 184, 7)',
    display: 'inline-block',
    cursor: 'pointer',
    color: 'rgb(255, 255, 255)',
    fontFamily: 'Arial',
    fontSize: '15px',
    fontWeight: 'bold',
    padding: '19px 76px',
    textShadow: 'rgb(82, 128, 9) 0px 1px 0px',
    width: '512px',
    margin: '15px'
  },
  divStyle:{
    width:'500px',
    minHeight:'100px',
    border:'2px solid gray',
    background:'rgb(215,215,215)',
    display:'none',
    borderRadius: '6px',
    marginLeft: '15px',
    fontFamily: 'Arial',
    position: 'relative',
    padding:'5px',
    marginBottom:'10px'
  },
  bodyStyle:{
    width:'488px',
    minHeight:'50px',
    border:'1px solid gray',
    borderRadius: '6px',
    background: 'white',
    fontFamily: 'Arial',
    padding: '5px',
    marginTop:'5px'
  }
};

class App extends React.Component {
  constructor(){
    super();
    this.state={
      updated: false,
      data:[]};
  }

  componentDidMount(){
    return fetch('https://api.github.com/issues',{
        headers:{'Authorization':'Basic Q3VsbGVuTTpNS08pOWlqbg=='}})
        .then((response) => response.json())
        .then((responseJson) => {this.setState(
          {updated:true, data: responseJson})})
          .catch((error) => {console.error(error);});
  }

   buttonClicked(number){
    var container = document.getElementById(number);
    var style = window.getComputedStyle(container);
    if(style.getPropertyValue('display')=='none'){
      container.style.display="block";
    }
    else{
      container.style.display="none";
    }
  }

  createButtons(){
    const buttons=[];
    for(let i = 0; i<this.state.data.length; i++){
      buttons.push(
        <div key={i} >
        <button onClick={()=>this.buttonClicked(i)}
          style={styles.buttonStyle}>
          {this.state.data[i].title}
        </button>
        <div id={i} style={styles.divStyle}>
          Created by: {this.state.data[i].user.login} <br/>
          Assigned to: {this.state.data[i].assignee.login}
          <div style={styles.bodyStyle}>
          {this.state.data[i].body}
          </div>
        </div>
      </div>
      )
    }
    return buttons;
  }

   render() {
        if(this.state.updated){
          return(
            <div>
              <div style={styles.headerStyle}>
                Issues from https://github.com/CullenM/ExampleProjects
              </div>
              <div>{this.createButtons()}</div>
            </div>
          );
        }
        else{
          return(
            <div>
              <h2>Whoops! Something went wrong.</h2>
            </div>
          );
        }
   }
}

export default App;
