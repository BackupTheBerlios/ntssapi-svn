<?php

if ( $config['no_news'] != '0' ) {

	$sql = 'SELECT * FROM ! order by date desc limit 0,' . $config['no_news'];
	

	$data = $db->getAll( $sql, array( NEWS_TABLE ) );

	foreach( $data as $index => $row ) {

		$row['date'] = date(LONG_DATE_FORMAT, $row['date'] );

	// how many characters should be displayed

		$arrtext = explode( ' ', $row['text'], $config['length_story'] + 1);

		$arrtext[$config['length_story']] = '';

		$row['text'] = trim(implode( ' ', $arrtext)) . '...';

		$data[ $index ] = $row;
	}

$t->assign ( 'news_data', $data );
}
?>