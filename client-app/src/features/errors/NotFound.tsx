import { Link } from "react-router-dom";
import { Button, Header, Icon, Segment } from "semantic-ui-react";



const NotFound=()=>{
    return(
        <Segment placeholder>
            <Header icon>
                <Icon name='search' />
                We've looked everywhere, but we didn't find it 

            </Header>
            <Segment.Inline>
                <Button as={Link} to='/activities' primary>Return to activities page </Button>
            </Segment.Inline>
            
        </Segment>
    )

}

export default NotFound;
