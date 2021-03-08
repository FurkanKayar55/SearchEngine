import React from 'react';
import axios from 'axios';

export default class Search extends React.Component {
  state = {
    query: '',
    isReady: false,
    pages: []
  }

  componentDidMount() {
    const query = this.props.query;
    const url = this.props.url;
    axios.get(`https://localhost:44349/api/Search/Index?Query=${query}&Url=${url}`)
      .then(res => {
        this.setState({ 
          pages: res.data.pages,
          query: query, 
          isReady: true
        });
      })
  }
  
  render() {
        let isReady = this.state.isReady;
        let pages = this.state.pages;
        let query = this.state.query;
        return (
          <div className="card">
          {isReady
          ? <h1>Your keyword "{query}" found on "{pages}" pages</h1>
          : <h1>It's Loading...</h1>
          }
          </div>
        )
        
  }
}

