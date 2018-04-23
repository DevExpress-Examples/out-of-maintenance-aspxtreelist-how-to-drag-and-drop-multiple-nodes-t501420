# ASPxTreeList - How to drag and drop multiple nodes


<p>The sample illustrates how to drag and drop multiple nodes in ASPxTreeList when selection is enabled. To replace selected nodes from one parent node to another, it's sufficient to change the selected nodes' parent property at the DataSource level. This can be done by handling the ASPxClientTreeList.EndDragNode event and performing the ASPxClientTreeList custom callback. On the server-side, it's necessary to handle the ASPxTreeList.CustomCallback event and change the parent property in this event handler.</p>
<p>The most interesting part of this task is to show all selected nodes in a transparent popup when dragging. This can be achieved by handling the StartDragNode event. After the StartDragNode event is raised, a div container is created after the form element. It's possible to find this container, clone a table row inside the div container and assign selected node values to cloned rows. The div container is created after the StartDragNode event is handled, so it's necessary to implement your own custom function and call it asynchronously from the StartDragNode event handler.</p>

<br/>


